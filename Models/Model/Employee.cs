using System.ComponentModel.DataAnnotations.Schema;
using Models.Entitys;

namespace Models.Model
{
    public class Employee : EntityClass
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string MiddleName { get; set; }
        public required string Position { get; set; }
        public Guid AccountId { get; set; }
        public Guid DepartmentId { get; set; }
        [NotMapped]
        public Account? Account { get; set; }
        [NotMapped]
        public Department? Department { get; set; }
        public DateTime AddedEmployee { get; set; } = DateTime.UtcNow; //اضافة تاريخ اضافة الموظف تلقائيا
        public List<Evaluation> evaluations { get; set; } = new List<Evaluation>();
        public List<Attendence> attendences { get; set; } = new List<Attendence>();
        public List<Leave> leaves { get; set; } = new List<Leave>();
        public List<Salary> salarys { get; set; } = new List<Salary>();
    }
}


