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
    public class EmployeeController : Controller
    {
        EmployeeCategoryService employeeCategoryService;
        EmployeeService employeeService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public EmployeeController(EmployeeCategoryService EmployeeCategoryService, EmployeeService EmployeeService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            employeeService = EmployeeService;
            employeeCategoryService = EmployeeCategoryService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstbEmployees = employeeService.getAll();
            model.lstEmployeeCategories = employeeCategoryService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbEmployee ITEM, List<IFormFile> files)
        {


            if (ITEM.EmployeeId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.EmployeeImagePath = ImageName;
                    }
                }


                var result = employeeService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Employee Profile successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Employee Profile  Creating.";
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
                        ITEM.EmployeeImagePath = ImageName;
                    }
                }




                var result = employeeService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Employee Profile successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Employee Profile  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lstbEmployees = employeeService.getAll();
            model.lstEmployeeCategories = employeeCategoryService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbEmployee oldItem = ctx.TbEmployees.Where(a => a.EmployeeId == id).FirstOrDefault();

            var result = employeeService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Employee Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Employee Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstbEmployees = employeeService.getAll();
            model.lstEmployeeCategories = employeeCategoryService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbEmployee oldItem = ctx.TbEmployees.Where(a => a.EmployeeId == id).FirstOrDefault();

            ViewBag.employeeCategories = employeeCategoryService.getAll();
            return View(oldItem);
        }
    }
}
