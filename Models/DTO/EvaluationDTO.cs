using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class EvaluationDTO
    {
        public string? Commints { get; set; }
        public Guid EmployeeId { get; set; }
        public int Eval { get; set; }

    }
}
