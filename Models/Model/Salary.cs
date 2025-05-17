using System;
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
        public DateTime SalaryDate { get; set; } = DateTime.Now;
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
