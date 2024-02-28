using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbExpenseCategory
    {
        public TbExpenseCategory()
        {
            TbExpenseTransactions = new HashSet<TbExpenseTransaction>();
        }

        public Guid ExpenseCategoryId { get; set; }
        public string ExpenseCategoryName { get; set; }
        public string ExpenseCategoryImage { get; set; }
        public string ExpenseCategoryDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbExpenseTransaction> TbExpenseTransactions { get; set; }
    }
}
