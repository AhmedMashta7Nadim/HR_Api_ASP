using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SalaryDTO
    {
        public decimal SalaryValue { get; set; }
        public decimal NetSalary { get; set; }
        public decimal Adjustment { get; set; }
        public Guid EmployeeId { get; set; }
        public bool IsReceiveSalary { get; set; }

    }
}
