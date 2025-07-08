using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;

namespace Models.Model
{
    public class Evaluation:EntityClass //التقييمات
    {
        public string? Commints { get; set; }
        public DateTime EvalDate { get; set; } = DateTime.UtcNow; // تاريخ التقييم
        public required int Eval { get; set; }
        public Guid EmployeeId { get; set; }
        [NotMapped]
        public Employee? Employee { get; set; }
    }
}
