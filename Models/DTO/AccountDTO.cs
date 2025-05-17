using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.enum_class;

namespace Models.DTO
{
    public class AccountDTO
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required Enum_RoleEmployee Role { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
