using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;
using Models.enum_class;

namespace Models.Summary
{
    public class DepartmentSummary:EntityClass
    {
        public required string DepartmentName { get; set; }
        public required Enum_Departmint Type_Departmint { get; set; }
    }
}
