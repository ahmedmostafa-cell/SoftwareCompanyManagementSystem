using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbProject
    {
        public TbProject()
        {
            TbProjectInstallments = new HashSet<TbProjectInstallment>();
        }

        public Guid ProjectId { get; set; }
        public Guid? ClientId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectSalesPrice { get; set; }
        public string ProjectInstallmentNumbers { get; set; }
        public Guid? SalesEmployeeId { get; set; }
        public string SalesEmployeePercentage { get; set; }
        public string WorkingEmployessNumber { get; set; }
        public string ProjectCost { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbProjectInstallment> TbProjectInstallments { get; set; }
    }
}
