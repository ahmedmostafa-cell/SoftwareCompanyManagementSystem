using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbEmployee
    {
        public TbEmployee()
        {
            TbEmployeeEvaluations = new HashSet<TbEmployeeEvaluation>();
            TbPaidProjectInstallments = new HashSet<TbPaidProjectInstallment>();
            TbPaidSalesEmplyeeInstallments = new HashSet<TbPaidSalesEmplyeeInstallment>();
        }

        public Guid EmployeeId { get; set; }
        public string EmplyeeName { get; set; }
        public string EmployeeJobDescription { get; set; }
        public string EmployeeImagePath { get; set; }
        public string EmployeeWorkHours { get; set; }
        public string EmplyeeWorkHourValue { get; set; }
        public string EmployeeSalary { get; set; }
        public Guid? EmployeeCategoryId { get; set; }
        public string EmployeeSalaryCalculate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbEmployeeCategory EmployeeCategory { get; set; }
        public virtual ICollection<TbEmployeeEvaluation> TbEmployeeEvaluations { get; set; }
        public virtual ICollection<TbPaidProjectInstallment> TbPaidProjectInstallments { get; set; }
        public virtual ICollection<TbPaidSalesEmplyeeInstallment> TbPaidSalesEmplyeeInstallments { get; set; }
    }
}
