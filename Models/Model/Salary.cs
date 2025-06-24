using System;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Entitys;

namespace Models.Model
{
    public class Salary : EntityClass
    {
        // الراتب الأساسي
        public decimal SalaryValue { get; set; }

        // الراتب الصافي بعد التعديلات
        public decimal NetSalary { get; set; }

        // التعديل على الراتب (مكافآت أو خصومات)
        public decimal Adjustment { get; set; }
        public bool IsReceiveSalary { get; set; } = false;
        public DateTime SalaryDate { get; set; } = DateTime.UtcNow;
        public Guid EmployeeId { get; set; }
        [NotMapped]
        public Employee? Employee { get; set; }
    }
}
