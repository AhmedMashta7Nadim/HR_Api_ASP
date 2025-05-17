using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;

namespace Models.Summary
{
    public class SalarySummary:EntityClass
    {
        public decimal SalaryValue { get; set; }
        public decimal NetSalary { get; set; }
        public decimal Adjustment { get; set; }
        public DateTime SalaryDate { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
