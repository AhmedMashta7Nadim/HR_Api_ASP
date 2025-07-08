using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;

namespace Models.Summary
{
    public class EvaluationSummary:EntityClass
    {
        public string? Commints { get; set; }
        public required int Eval { get; set; }
        public DateTime EvalDate { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
