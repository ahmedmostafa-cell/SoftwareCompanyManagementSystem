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
    public class ProjectInstallmentController : Controller
    {
        ProjectInstallmentService projectInstallmentService;
        EmployeeService employeeService;
        ClientService clientService;
        ProjectService projectService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ProjectInstallmentController(ProjectInstallmentService ProjectInstallmentService,EmployeeService EmployeeService, ProjectService ProjectService, ClientService ClientService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            projectService = ProjectService;
            Usermanager = usermanager;
            clientService = ClientService;
            employeeService = EmployeeService;
            projectInstallmentService = ProjectInstallmentService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            model.lstProjectInstallments = projectInstallmentService.getAll().Where(a=> a.CurrentState == 1);
            model.lstProjects = projectService.getAll();
            model.lstbEmployees = employeeService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbProjectInstallment ITEM, List<IFormFile> files)
        {


            if (ITEM.ProjectInstallmentId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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


                var result = projectInstallmentService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Project Installment successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Project Installment  Creating.";
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




                var result = projectInstallmentService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Project Installment successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Project Installment  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            model.lstProjectInstallments = projectInstallmentService.getAll().Where(a => a.CurrentState == 1);
            model.lstProjects = projectService.getAll();
            model.lstbEmployees = employeeService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbProjectInstallment oldItem = ctx.TbProjectInstallments.Where(a => a.ClientId == id).FirstOrDefault();

            var result = projectInstallmentService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Project Installment successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Project Installment  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            model.lstProjectInstallments = projectInstallmentService.getAll();
            model.lstProjects = projectService.getAll();
            model.lstbEmployees = employeeService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbProjectInstallment oldItem = ctx.TbProjectInstallments.Where(a => a.ProjectInstallmentId == id).FirstOrDefault();

            ViewBag.Projects = projectService.getAll();
            ViewBag.Clients = clientService.getAll();
            ViewBag.Employees = employeeService.getAll().Where(a => a.EmployeeCategoryId == Guid.Parse("935b10a7-b48d-4ae6-a7a7-df2630dbb7ef"));
            return View(oldItem);
        }
    }
}
