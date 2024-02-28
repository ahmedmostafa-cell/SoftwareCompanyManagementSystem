using BL;
using EibtekSystemProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using Domains;
using System.Linq;

namespace EibtekSystemProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientController : Controller
    {
        ClientService clientService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ClientController(ClientService ClientService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            clientService = ClientService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbClient ITEM, List<IFormFile> files)
        {

            
            if (ITEM.ClientId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ClientImagePath = ImageName;
                    }
                }


                var result = clientService.Add(ITEM);
                if(result == true)
                {
                    TempData[SD.Success] = "Client Profile successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Client Profile  Creating.";
                }


            }
            else
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ClientImagePath = ImageName;
                    }
                }




                var result = clientService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Client Profile successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Client Profile  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbClient oldItem = ctx.TbClients.Where(a => a.ClientId == id).FirstOrDefault();

            var result = clientService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Client Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Client Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbClient oldItem = ctx.TbClients.Where(a => a.ClientId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
