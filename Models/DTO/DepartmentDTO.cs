using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.enum_class;

namespace Models.DTO
{
    public class DepartmentDTO
    {
        public required string DepartmentName { get; set; }
        public required Enum_Departmint Type_Departmint { get; set; }
    }
}
