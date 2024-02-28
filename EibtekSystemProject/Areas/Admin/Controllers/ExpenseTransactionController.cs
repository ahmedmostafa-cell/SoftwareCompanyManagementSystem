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
    public class ExpenseTransactionController : Controller
    {
        ExpenseTransactionService expenseTransactionService;
        ExpenseCategoryService expenseCategoryService;
        EibtekSystemDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ExpenseTransactionController(ExpenseTransactionService ExpenseTransactionService,ExpenseCategoryService ExpenseCategoryService, ClientService ClientService, UserManager<ApplicationUser> usermanager, EibtekSystemDbContext context)
        {

            ctx = context;
            expenseCategoryService = ExpenseCategoryService;
            Usermanager = usermanager;
            expenseTransactionService = ExpenseTransactionService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstExpenseCategories = expenseCategoryService.getAll();
            model.lstExpenseTransactions = expenseTransactionService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbExpenseTransaction ITEM, List<IFormFile> files)
        {


            if (ITEM.ExpenseTransactionId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.ExpenseTransactionDocument = ImageName;
                    }
                }


                var result = expenseTransactionService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Expense Transaction successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Expense Transaction  Creating.";
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
                        ITEM.ExpenseTransactionDocument = ImageName;
                    }
                }




                var result = expenseTransactionService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "Expense Transaction successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in Expense Transaction  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lstExpenseCategories = expenseCategoryService.getAll();
            model.lstExpenseTransactions = expenseTransactionService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbExpenseTransaction oldItem = ctx.TbExpenseTransactions.Where(a => a.ExpenseTransactionId == id).FirstOrDefault();

            var result = expenseTransactionService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Expense Transaction successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Expense Transaction  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstExpenseCategories = expenseCategoryService.getAll();
            model.lstExpenseTransactions = expenseTransactionService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbExpenseTransaction oldItem = ctx.TbExpenseTransactions.Where(a => a.ExpenseTransactionId == id).FirstOrDefault();

            ViewBag.ExpenseCategory = expenseCategoryService.getAll();
            return View(oldItem);
        }
    }
}
