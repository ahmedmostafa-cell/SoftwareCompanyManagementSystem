using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbEmployeeEvaluation
    {
        public Guid EmployeeEvaluationId { get; set; }
        public Guid? EmployeeId { get; set; }
        public string EvaluationSyntax { get; set; }
        public string EvaluationNumerical { get; set; }
        public string EmployeeBasicWorkHours { get; set; }
        public string EmployeeExtraWorkHours { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbEmployee Employee { get; set; }
    }
}
