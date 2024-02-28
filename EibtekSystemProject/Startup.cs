using BL;
using EibtekSystemProject.Authorize;
using EibtekSystemProject.Hubs;
using EibtekSystemProject.Models;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EibtekSystemProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var emailConfig = Configuration
         .GetSection("EmailConfiguration")
         .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddAuthentication()
             .AddGoogle(options =>
             {
                 options.ClientId = "975214719409-pp37jcmifi7bg33254ve18ku83telt9r.apps.googleusercontent.com";
                 options.ClientSecret = "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";


             });



            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "1387677424973135";
                options.AppSecret = "de6fc7e479121219c97a2e079eee1b3e";
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserAndAdmin", policy => policy.RequireRole("Admin").RequireRole("User"));
                options.AddPolicy("Admin_CreateAccess", policy => policy.RequireRole("Admin").RequireClaim("create", "True"));
                options.AddPolicy("Admin_Create_Edit_DeleteAccess", policy => policy.RequireRole("Admin").RequireClaim("create", "True")
                .RequireClaim("edit", "True")
                .RequireClaim("Delete", "True"));

                options.AddPolicy("Admin_Create_Edit_DeleteAccess_OR_SuperAdmin", policy => policy.RequireAssertion(context =>
                AuthorizeAdminWithClaimsOrSuperAdmin(context)));
                options.AddPolicy("OnlySuperAdminChecker", policy => policy.Requirements.Add(new OnlySuperAdminChecker()));
                options.AddPolicy("AdminWithMoreThan1000Days", policy => policy.Requirements.Add(new AdminWithMoreThan1000DaysRequirement(1000)));
                options.AddPolicy("FirstNameAuth", policy => policy.Requirements.Add(new FirstNameAuthRequirement("ahmedmostafa706@gmail.com")));
            });
            services.AddScoped<IAuthorizationHandler, AdminWithOver1000DaysHandler>();
            services.AddScoped<IAuthorizationHandler, FirstNameAuthHandler>();
            services.AddScoped<INumberOfDaysForAccount, NumberOfDaysForAccount>();
            services.AddControllersWithViews();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddSignalR();
            services.AddScoped<ClientService, ClsClients>();
            services.AddScoped<EmployeeCategoryService, ClsEmployeeCategories>();
            services.AddScoped<EmployeeEvaluationService, ClsEmployeeEvaluations>();
            services.AddScoped<EmployeeService, ClsEmployees>();
            services.AddScoped<ExpenseCategoryService, ClsExpenseCategories>();
            services.AddScoped<ExpenseTransactionService, ClsExpenseTransactions>();
            services.AddScoped<MonthRecordService, ClsMonthRecord>();
            services.AddScoped<PaidProjectInstallmentService, ClsPaidProjectInstallments>();
            services.AddScoped<PaidSalesEmplyeeInstallmentService, ClsPaidSalesEmplyeeInstallments>();
            services.AddScoped<ProjectInstallmentService, ClsProjectInstallment>();
            services.AddScoped<ProjectService, ClsProjects>();
            services.AddRazorPages();
            services.AddDbContext<EibtekSystemDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.SignIn.RequireConfirmedEmail = true;

            }).AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<EibtekSystemDbContext>().AddDefaultTokenProviders();    ///.AddDefaultUI();


            services.ConfigureApplicationCookie(opt =>
            {
                opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Accessdenied");
            });
            //Add sessions
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}");
               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<UserHub>("/hubs/userCount");

            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
        private bool AuthorizeAdminWithClaimsOrSuperAdmin(AuthorizationHandlerContext context)
        {
            return (context.User.IsInRole("Admin") && context.User.HasClaim(c => c.Type == "Create" && c.Value == "True")
                        && context.User.HasClaim(c => c.Type == "Edit" && c.Value == "True")
                        && context.User.HasClaim(c => c.Type == "Delete" && c.Value == "True")
                    ) || context.User.IsInRole("SuperAdmin");
        }
    }
}
