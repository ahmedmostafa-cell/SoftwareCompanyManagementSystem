using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbExpenseTransaction
    {
        public Guid ExpenseTransactionId { get; set; }
        public Guid? ExpenseCategoryId { get; set; }
        public string ExpenseTransactionDescription { get; set; }
        public string ExpenseTransactionValue { get; set; }
        public string ExpenseTransactionDocument { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbExpenseCategory ExpenseCategory { get; set; }
    }
}
