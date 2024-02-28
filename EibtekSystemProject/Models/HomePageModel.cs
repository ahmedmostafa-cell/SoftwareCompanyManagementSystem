using BL;
using Domains;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EibtekSystemProject.Models
{
    public class HomePageModel
    {
        #region Declaration


        public IEnumerable<ApplicationUser> UserData { get; set; }

        public string ImageProfile { get; set; }

        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

      

        public ApplicationUser OneUser { get; set; }


        public IEnumerable<ApplicationUser> lstUsers { get; set; }

      


        public IEnumerable<TbClient> lsClients { get; set; }

        public IEnumerable<TbEmployeeCategory> lstEmployeeCategories { get; set; }

        public IEnumerable<TbEmployee> lstbEmployees { get; set; }

        public IEnumerable<TbEmployeeEvaluation> lstEmployeeEvaluations { get; set; }

        public IEnumerable<TbExpenseCategory> lstExpenseCategories { get; set; }
        public IEnumerable<TbExpenseTransaction> lstExpenseTransactions { get; set; }
        public IEnumerable<TbProject> lstProjects { get; set; }
        public IEnumerable<TbMonthRecord> lstMonthRecords { get; set; }
        public IEnumerable<TbPaidProjectInstallment> lstPaidProjectInstallments { get; set; }
        public IEnumerable<TbPaidSalesEmplyeeInstallment> lstPaidSalesEmplyeeInstallments { get; set; }
        public IEnumerable<TbProjectInstallment> lstProjectInstallments { get; set; }






        #endregion
    }
}
