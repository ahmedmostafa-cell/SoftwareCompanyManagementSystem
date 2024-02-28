using BL;
using Domains;
using EibtekSystemProject.Models;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace EibtekSystemProject.Areas.Admin.Controllers
{
  

    
  
    public class MySearch
    {

        public IFormFile files { get; set; }
        public string ProjectSalesPrice { get; set; }
        public string SalesEmployeeId { get; set; }
        public string SalesEmployeePercentage { get; set; }
        public string WorkingEmployessNumber { get; set; }

        public string ProjectCost { get; set; }


        public string ProjectName { get; set; }

        public bool OnlyActive { get; set; } = true;

        public string ClientId { get; set; }

        public string ProjectInstallmentNumbers { get; set; }

        public string ProjectDescription { get; set; }


        public List<string> Idsdate { get; set; }
        public List<string> Ids { get; set; }
    }
    [Area("Admin")]
   
    public class ProjectController : Controller
    {
        EmployeeService employeeService;
        ClientService clientService;
        ProjectService projectService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ProjectController(EmployeeService EmployeeService, ProjectService ProjectService,ClientService ClientService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            projectService = ProjectService;
            Usermanager = usermanager;
            clientService = ClientService;
            employeeService = EmployeeService;
        }
     
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstProjects = projectService.getAll();
            model.lsClients = clientService.getAll();
            model.lstbEmployees = employeeService.getAll();
            return View(model);


        }

        [HttpPost]
        public async Task<IActionResult> Save( MySearch arr)
        {
            TbProject ITEM = new TbProject();
            if (arr.files.Length > 0)
            {
                string ImageName = Guid.NewGuid().ToString() + ".pdf";
                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                using (var stream = System.IO.File.Create(filePaths))
                {
                    await arr.files.CopyToAsync(stream);
                }
                ITEM.Notes = ImageName;
            }

           

            ITEM.ProjectName= arr.ProjectName;
            ITEM.ProjectDescription= arr.ProjectDescription;
            ITEM.ProjectSalesPrice = arr.ProjectSalesPrice;
            ITEM.ProjectDescription = arr.ProjectDescription;
            ITEM.SalesEmployeePercentage = arr.SalesEmployeePercentage;
            ITEM.WorkingEmployessNumber = arr.WorkingEmployessNumber;
            ITEM.SalesEmployeeId = Guid.Parse(arr.SalesEmployeeId);
            ITEM.ClientId = Guid.Parse(arr.ClientId);
            ITEM.ProjectSalesPrice = arr.ProjectSalesPrice;
            ITEM.ProjectCost = arr.ProjectCost;
            ITEM.ProjectInstallmentNumbers = arr.ProjectInstallmentNumbers;
            var result = projectService.Add(ITEM);
            if (result == true)
            {
                TempData[SD.Success] = "Project Profile successfully Created.";
            }
            else
            {
                TempData[SD.Error] = "Error in Project Profile  Creating.";
            }



            for (int i =0; i <arr.Ids.Count; i++ ) {
                TbProjectInstallment el = new TbProjectInstallment();

                el.ProjectId = ITEM.ProjectId;
                el.ProjectInstallmentValue = arr.Ids[i];
                el.ClientId = Guid.Parse(arr.ClientId);
                el.SalesEmployeeId = Guid.Parse(arr.SalesEmployeeId);
                el.ProjectInstallmentDate = arr.Idsdate[i];
                int a = int.Parse(ITEM.SalesEmployeePercentage);
                int b = int.Parse(el.ProjectInstallmentValue);
                el.SalesInstallmentValue = ((a * b)/100).ToString();
                ctx.TbProjectInstallments.Add(el);
                ctx.SaveChanges();


            }
           

















            HomePageModel model = new HomePageModel();
            model.lstProjects = projectService.getAll();
            model.lsClients = clientService.getAll();
            model.lstbEmployees = employeeService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbProject oldItem = ctx.TbProjects.Where(a => a.ProjectId == id).FirstOrDefault();

            var result = projectService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Project Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Project Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstProjects = projectService.getAll();
            model.lsClients = clientService.getAll();
            model.lstbEmployees = employeeService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbProject oldItem = ctx.TbProjects.Where(a => a.ProjectId == id).FirstOrDefault();
            ViewBag.Clients = clientService.getAll();
            ViewBag.Employees = employeeService.getAll().Where(a=> a.EmployeeCategoryId == Guid.Parse("935b10a7-b48d-4ae6-a7a7-df2630dbb7ef"));
            return View(oldItem);
        }
    }
}
