using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbClient
    {
        public TbClient()
        {
            TbProjectInstallments = new HashSet<TbProjectInstallment>();
        }

        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientImagePath { get; set; }
        public string ClientCompanyDescription { get; set; }
        public string ClientCompanyLocation { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbProjectInstallment> TbProjectInstallments { get; set; }
    }
}
