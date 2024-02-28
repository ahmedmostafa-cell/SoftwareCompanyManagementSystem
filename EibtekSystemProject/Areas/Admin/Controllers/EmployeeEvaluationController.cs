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
    public class EmployeeEvaluationController : Controller
    {
        EmployeeCategoryService employeeCategoryService;
        EmployeeService employeeService;
        EmployeeEvaluationService employeeEvaluationService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public EmployeeEvaluationController(EmployeeCategoryService EmployeeCategoryService, EmployeeService EmployeeService,EmployeeEvaluationService EmployeeEvaluationService,ClientService ClientService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            employeeEvaluationService = EmployeeEvaluationService;
            Usermanager = usermanager;
            employeeService = EmployeeService;
            employeeCategoryService = EmployeeCategoryService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstbEmployees = employeeService.getAll();
            model.lstEmployeeCategories = employeeCategoryService.getAll();
            model.lstEmployeeEvaluations = employeeEvaluationService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbEmployeeEvaluation ITEM, List<IFormFile> files)
        {


            if (ITEM.EmployeeEvaluationId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                //        ITEM.EmployeeImagePath = ImageName;
                //    }
                //}


                var result = employeeEvaluationService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Employee Evaluation successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Employee Evaluation  Creating.";
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
                //        ITEM.EmployeeImagePath = ImageName;
                //    }
                //}




                var result = employeeEvaluationService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Employee Evaluation successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Employee Evaluation  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lstbEmployees = employeeService.getAll();
            model.lstEmployeeCategories = employeeCategoryService.getAll();
            model.lstEmployeeEvaluations = employeeEvaluationService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbEmployeeEvaluation oldItem = ctx.TbEmployeeEvaluations.Where(a => a.EmployeeEvaluationId == id).FirstOrDefault();

            var result = employeeEvaluationService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Employee Evaluation successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Employee Evaluation  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstbEmployees = employeeService.getAll();
            model.lstEmployeeCategories = employeeCategoryService.getAll();
            model.lstEmployeeEvaluations = employeeEvaluationService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbEmployeeEvaluation oldItem = ctx.TbEmployeeEvaluations.Where(a => a.EmployeeEvaluationId == id).FirstOrDefault();

            ViewBag.employeeCategories = employeeCategoryService.getAll();
            ViewBag.Employees = employeeService.getAll();
            return View(oldItem);
        }
    }
}
