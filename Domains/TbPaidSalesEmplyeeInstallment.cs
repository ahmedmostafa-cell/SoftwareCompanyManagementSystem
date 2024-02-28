using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbPaidSalesEmplyeeInstallment
    {
        public Guid PaidSalesEmplyeeInstallmentId { get; set; }
        public Guid? SalesEmployeeId { get; set; }
        public Guid? ProjectInstallmentId { get; set; }
        public string SalesInstallmentValue { get; set; }
        public string PaidSalesInstallmentValue { get; set; }
        public string PaidSalesInstallmentValueDocument { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbProjectInstallment ProjectInstallment { get; set; }
        public virtual TbEmployee SalesEmployee { get; set; }
    }
}
