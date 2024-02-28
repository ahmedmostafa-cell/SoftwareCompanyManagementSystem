using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbPaidProjectInstallment
    {
        public Guid PaidProjectInstallmentId { get; set; }
        public Guid? SalesEmployeeId { get; set; }
        public Guid? ProjectInstallmentId { get; set; }
        public string ProjectInstallmentValue { get; set; }
        public string PaidProjectInstallmentValue { get; set; }
        public string PaidProjectInstallmentDocument { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbProjectInstallment ProjectInstallment { get; set; }
        public virtual TbEmployee SalesEmployee { get; set; }
    }
}
