using Models.Entitys;
using Models.enum_class;

namespace Models.Model
{
    public class Department : EntityClass
    {
        public required string DepartmentName { get; set; }
        public required Enum_Departmint Type_Departmint { get; set; }
        public List<Employee> employees { get; set; }=new List<Employee>();
    }
}
