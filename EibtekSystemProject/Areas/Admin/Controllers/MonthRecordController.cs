using BL;
using Domains;
using EibtekSystemProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace EibtekSystemProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MonthRecordController : Controller
    {
        MonthRecordService monthRecordService;
        ClientService clientService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public MonthRecordController(MonthRecordService MonthRecordService,ClientService ClientService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            clientService = ClientService;
            Usermanager = usermanager;
            monthRecordService = MonthRecordService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            model.lstMonthRecords = monthRecordService.getAll();    
            return View(model);


        }


        public async Task<IActionResult> Save(TbMonthRecord ITEM, List<IFormFile> files)
        {


            if (ITEM.MonthRecordId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                //foreach (var file in files)
                //{
                //    if (file.Length > 0)
                //    {
                //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                //        using (var stream = System.IO.File.Create(filePaths))
                //        {
                //            await file.CopyToAsync(stream);
                //        }
                //        ITEM.ClientImagePath = ImageName;
                //    }
                //}


                var result = monthRecordService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Month Record  successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Month Record  Creating.";
                }


            }
            else
            {
                //foreach (var file in files)
                //{
                //    if (file.Length > 0)
                //    {
                //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                //        using (var stream = System.IO.File.Create(filePaths))
                //        {
                //            await file.CopyToAsync(stream);
                //        }
                //        ITEM.ClientImagePath = ImageName;
                //    }
                //}




                var result = monthRecordService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Month Record successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Month Record  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            model.lstMonthRecords = monthRecordService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbMonthRecord oldItem = ctx.TbMonthRecords.Where(a => a.MonthRecordId == id).FirstOrDefault();

            var result = monthRecordService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Month Record successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Month Record  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            model.lstMonthRecords = monthRecordService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbMonthRecord oldItem = ctx.TbMonthRecords.Where(a => a.MonthRecordId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
