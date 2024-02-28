using BL;
using EibtekSystemProject.Models;
using Firebase.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.CodeAnalysis.Host;
using System.IO;

namespace EibtekSystemProject.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private IHostingEnvironment env;
        public string result;
        FirebaseAuthProvider auth;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(IConfiguration Configuration,IHostingEnvironment Env,UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _userManager = userManager;
            auth = new FirebaseAuthProvider(
                            new FirebaseConfig("AIzaSyCUoKOJP1aGqzElm_GberDBv3lwO5WGsco"));
            env = Env;
            configuration = Configuration;
        }
        public async Task OnGetAsync()
        {
            var path = env.ContentRootPath;
            path = path + "\\Auth.json";
            FirebaseApp app = null;
            try
            {
                app = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(path)
                }, "myApp");
            }
            catch (Exception ex)
            {
                app = FirebaseApp.GetInstance("myApp");
            }

            var fcm = FirebaseAdmin.Messaging.FirebaseMessaging.GetMessaging(app);
            Message message = new Message()
            {
                Notification = new Notification
                {
                    Title = "My push notification title",
                    Body = "Content for this push notification"
                },
                Data = new Dictionary<string, string>()
                 {
                     { "AdditionalData1", "data 1" },
                     { "AdditionalData2", "data 2" },
                     { "AdditionalData3", "data 3" },
                 },

                Topic = "WebsiteUpdates"
            };

            this.result = await fcm.SendAsync(message);
        }
        public IActionResult SUBSCRIPE()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Index(string client, string endpoint, string p256dh, string auth)
        //{
        //    if (client == null)
        //    {
        //        return BadRequest("No Client Name parsed.");
        //    }
        //    if (PersistentStorage.GetClientNames().Contains(client))
        //    {
        //        return BadRequest("Client Name already used.");
        //    }
        //    var subscription = new PushSubscription(endpoint, p256dh, auth);
        //    PersistentStorage.SaveSubscription(client, subscription);
        //    return View("Notify", PersistentStorage.GetClientNames());
        //}
        public async Task<IActionResult>  Index()
        {
            ViewBag.applicationServerKey = configuration["VAPID:publicKey"];

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ViewData["TwoFactorEnabled"] = false;
            }
            else
            {
                ViewData["TwoFactorEnabled"] = user.TwoFactorEnabled;
            }

            //FirebaseApp.Create(new AppOptions()
            //{
            //    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "private_key.json"))
            //});
            //var registerationToken = "ADD_TOKEN";
            //var message = new Message()
            //{
            //    Topic = "aaaa",
            //    Data = new Dictionary<string, string>()
            //    {
            //        { "myData", "1337" },
            //    },
            //    //Token = registerationToken,
            //    Notification = new Notification()
            //    {
            //        Title = "test from code",
            //        Body = "here is my test"
            //    }
                
            //};
            //string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            return View();
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
