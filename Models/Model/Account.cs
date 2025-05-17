using Models.Entitys;
using Models.enum_class;

namespace Models.Model
{
    public class Account : EntityClass
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required Enum_RoleEmployee Role { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
