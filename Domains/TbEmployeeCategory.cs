using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbEmployeeCategory
    {
        public TbEmployeeCategory()
        {
            TbEmployees = new HashSet<TbEmployee>();
        }

        public Guid EmployeeCategoryId { get; set; }
        public string EmplyeeCategoryName { get; set; }
        public string EmplyeeCategoryJobDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbEmployee> TbEmployees { get; set; }
    }
}
