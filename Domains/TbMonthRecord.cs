using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbMonthRecord
    {
        public Guid MonthRecordId { get; set; }
        public string MonthName { get; set; }
        public string MonthNumber { get; set; }
        public string Year { get; set; }
        public string Income { get; set; }
        public string Expense { get; set; }
        public string NetIncome { get; set; }
        public string ManagementValue { get; set; }
        public string ZakahValue { get; set; }
        public string CompanyValue { get; set; }
        public string Fund { get; set; }
        public string WithdrawalValue { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
