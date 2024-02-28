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
    public class PaidProjectInstallmentController : Controller
    {
        ProjectInstallmentService projectInstallmentService;
        PaidProjectInstallmentService paidProjectInstallmentService;
        EmployeeService employeeService;
        ClientService clientService;
        ProjectService projectService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public PaidProjectInstallmentController(ProjectInstallmentService ProjectInstallmentService,PaidProjectInstallmentService PaidProjectInstallmentService,EmployeeService EmployeeService, ProjectService ProjectService, ClientService ClientService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            projectService = ProjectService;
            Usermanager = usermanager;
            clientService = ClientService;
            employeeService = EmployeeService;
            paidProjectInstallmentService = PaidProjectInstallmentService;
            projectInstallmentService = ProjectInstallmentService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            model.lstPaidProjectInstallments = paidProjectInstallmentService.getAll().Where(a=> a.CurrentState ==1);
            model.lstbEmployees = employeeService.getAll().Where(a => a.EmployeeCategoryId == Guid.Parse("935b10a7-b48d-4ae6-a7a7-df2630dbb7ef"));
            model.lstProjects = projectService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbPaidProjectInstallment ITEM, List<IFormFile> files)
        {
           
          

            if (ITEM.PaidProjectInstallmentId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                int pays = 0;
                if (ctx.TbPaidProjectInstallments.Where(a => a.ProjectInstallmentId == ITEM.ProjectInstallmentId).ToList().Count > 0)
                {
                    foreach (var i in ctx.TbPaidProjectInstallments.Where(a => a.ProjectInstallmentId == ITEM.ProjectInstallmentId).ToList())
                    {
                        pays += int.Parse(i.PaidProjectInstallmentValue);
                    }
                    TbProjectInstallment ooTbProjectInstallment = ctx.TbProjectInstallments.Where(a => a.ProjectInstallmentId == ITEM.ProjectInstallmentId).FirstOrDefault();
                    if (int.Parse(ITEM.PaidProjectInstallmentValue) + pays == int.Parse(ITEM.ProjectInstallmentValue) || int.Parse(ITEM.PaidProjectInstallmentValue) + pays > int.Parse(ITEM.ProjectInstallmentValue))
                    {
                        ooTbProjectInstallment.CurrentState = 0;
                        int totlaPay = int.Parse(ITEM.PaidProjectInstallmentValue) + pays;
                        ooTbProjectInstallment.CreatedBy = totlaPay.ToString();
                    }
                    else
                    {
                        int totlaPay = int.Parse(ITEM.PaidProjectInstallmentValue) + pays;
                        ooTbProjectInstallment.CreatedBy = totlaPay.ToString();
                    }
                    projectInstallmentService.Edit(ooTbProjectInstallment);


                }
                else
                {
                    TbProjectInstallment oTbProjectInstallment = ctx.TbProjectInstallments.Where(a => a.ProjectInstallmentId == ITEM.ProjectInstallmentId).FirstOrDefault();
                    if (ITEM.PaidProjectInstallmentValue == ITEM.ProjectInstallmentValue || int.Parse(ITEM.PaidProjectInstallmentValue) > int.Parse(ITEM.ProjectInstallmentValue))
                    {
                        oTbProjectInstallment.CurrentState = 0;
                        oTbProjectInstallment.CreatedBy = ITEM.PaidProjectInstallmentValue;
                    }
                    else
                    {
                        oTbProjectInstallment.CreatedBy = ITEM.PaidProjectInstallmentValue;
                    }
                    projectInstallmentService.Edit(oTbProjectInstallment);
                }
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".pdf";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.PaidProjectInstallmentDocument = ImageName;
                    }
                }


                var result = paidProjectInstallmentService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Paid Project Installment successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Paid Project Installment  Creating.";
                }


            }
            else
            {
               
                    TbProjectInstallment oTbProjectInstallment = ctx.TbProjectInstallments.Where(a => a.ProjectInstallmentId == ITEM.ProjectInstallmentId).FirstOrDefault();
                    if (ITEM.PaidProjectInstallmentValue == ITEM.ProjectInstallmentValue || int.Parse(ITEM.PaidProjectInstallmentValue) > int.Parse(ITEM.ProjectInstallmentValue))
                    {
                        oTbProjectInstallment.CurrentState = 0;
                        oTbProjectInstallment.CreatedBy = ITEM.PaidProjectInstallmentValue;
                    }
                    else
                    {
                        oTbProjectInstallment.CreatedBy = ITEM.PaidProjectInstallmentValue;
                    }
                    projectInstallmentService.Edit(oTbProjectInstallment);
              
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
                        ITEM.PaidProjectInstallmentDocument = ImageName;
                    }
                }




                var result = paidProjectInstallmentService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Paid Project Installment successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Paid Project Installment  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            model.lstPaidProjectInstallments = paidProjectInstallmentService.getAll().Where(a => a.CurrentState == 1);
            model.lstbEmployees = employeeService.getAll().Where(a => a.EmployeeCategoryId == Guid.Parse("935b10a7-b48d-4ae6-a7a7-df2630dbb7ef"));
            model.lstProjects = projectService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbPaidProjectInstallment oldItem = ctx.TbPaidProjectInstallments.Where(a => a.PaidProjectInstallmentId == id).FirstOrDefault();

            var result = paidProjectInstallmentService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Paid Project Installment successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Paid Project Installment  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lsClients = clientService.getAll();
            model.lstPaidProjectInstallments = paidProjectInstallmentService.getAll().Where(a => a.CurrentState == 1);
            model.lstbEmployees = employeeService.getAll().Where(a => a.EmployeeCategoryId == Guid.Parse("935b10a7-b48d-4ae6-a7a7-df2630dbb7ef"));
            model.lstProjects = projectService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbPaidProjectInstallment oldItem = ctx.TbPaidProjectInstallments.Where(a => a.PaidProjectInstallmentId == id).FirstOrDefault();

            ViewBag.Employees = employeeService.getAll().Where(a => a.EmployeeCategoryId == Guid.Parse("935b10a7-b48d-4ae6-a7a7-df2630dbb7ef"));
            return View(oldItem);
        }


        public IActionResult Form2(Guid? id)
        {
            TbProjectInstallment oTbProjectInstallment = ctx.TbProjectInstallments.Where(a => a.ProjectInstallmentId == id).FirstOrDefault();
            
            TbPaidProjectInstallment oldItem = new TbPaidProjectInstallment();
            oldItem.ProjectInstallmentId =oTbProjectInstallment.ProjectInstallmentId;
            oldItem.CreatedBy = oTbProjectInstallment.ProjectId.ToString();
            oldItem.SalesEmployeeId = oTbProjectInstallment.SalesEmployeeId;
            oldItem.ProjectInstallmentValue = oTbProjectInstallment.ProjectInstallmentValue;
            oldItem.UpdatedBy = oTbProjectInstallment.ProjectInstallmentDate;

            ViewBag.Employees = employeeService.getAll().Where(a => a.EmployeeCategoryId == Guid.Parse("935b10a7-b48d-4ae6-a7a7-df2630dbb7ef"));
            return View(oldItem);
        }
    }
}
