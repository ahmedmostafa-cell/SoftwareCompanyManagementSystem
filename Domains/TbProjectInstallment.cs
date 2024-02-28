using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbProjectInstallment
    {
        public TbProjectInstallment()
        {
            TbPaidProjectInstallments = new HashSet<TbPaidProjectInstallment>();
            TbPaidSalesEmplyeeInstallments = new HashSet<TbPaidSalesEmplyeeInstallment>();
        }

        public Guid ProjectInstallmentId { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? SalesEmployeeId { get; set; }
        public string ProjectInstallmentDescription { get; set; }
        public string ProjectInstallmentValue { get; set; }
        public string SalesInstallmentValue { get; set; }
        public string ProjectInstallmentDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbClient Client { get; set; }
        public virtual TbProject Project { get; set; }
        public virtual ICollection<TbPaidProjectInstallment> TbPaidProjectInstallments { get; set; }
        public virtual ICollection<TbPaidSalesEmplyeeInstallment> TbPaidSalesEmplyeeInstallments { get; set; }
    }
}
