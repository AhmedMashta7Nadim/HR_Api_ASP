using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;

namespace Models.Summary
{
    public class AttendenceSummary:EntityClass
    {
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
