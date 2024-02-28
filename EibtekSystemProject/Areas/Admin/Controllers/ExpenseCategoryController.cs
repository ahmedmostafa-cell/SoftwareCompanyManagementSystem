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

namespace EibtekSystemProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExpenseCategoryController : Controller
    {
        ExpenseCategoryService expenseCategoryService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ExpenseCategoryController(ExpenseCategoryService ExpenseCategoryService,ClientService ClientService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            expenseCategoryService = ExpenseCategoryService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstExpenseCategories = expenseCategoryService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbExpenseCategory ITEM, List<IFormFile> files)
        {


            if (ITEM.ExpenseCategoryId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.ExpenseCategoryImage = ImageName;
                    }
                }


                var result = expenseCategoryService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Expense Category successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Expense Category  Creating.";
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
                        ITEM.ExpenseCategoryImage = ImageName;
                    }
                }




                var result = expenseCategoryService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Expense Category successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Expense Category  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lstExpenseCategories = expenseCategoryService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbExpenseCategory oldItem = ctx.TbExpenseCategories.Where(a => a.ExpenseCategoryId == id).FirstOrDefault();

            var result = expenseCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Expense Category successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Expense Category  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstExpenseCategories = expenseCategoryService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbExpenseCategory oldItem = ctx.TbExpenseCategories.Where(a => a.ExpenseCategoryId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
