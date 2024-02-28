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
    public class EmployeeCategoryController : Controller
    {
        EmployeeCategoryService employeeCategoryService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public EmployeeCategoryController(EmployeeCategoryService EmployeeCategoryService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            employeeCategoryService = EmployeeCategoryService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstEmployeeCategories = employeeCategoryService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbEmployeeCategory ITEM)
        {


            if (ITEM.EmployeeCategoryId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                var result = employeeCategoryService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Employee Category Profile successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Employee Category Profile  Creating.";
                }


            }
            else
            {





                var result = employeeCategoryService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Employee Category Profile successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Employee Category Profile  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lstEmployeeCategories = employeeCategoryService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbEmployeeCategory oldItem = ctx.TbEmployeeCategories.Where(a => a.EmployeeCategoryId == id).FirstOrDefault();

            var result = employeeCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Employee Category Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Employee Category Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstEmployeeCategories = employeeCategoryService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbEmployeeCategory oldItem = ctx.TbEmployeeCategories.Where(a => a.EmployeeCategoryId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
