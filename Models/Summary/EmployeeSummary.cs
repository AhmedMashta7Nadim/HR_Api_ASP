using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;

namespace Models.Summary
{
    public class EmployeeSummary:EntityClass
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string MiddleName { get; set; }
        public required string Position { get; set; }
        public DateTime AddedEmployee { get; set; } = DateTime.UtcNow;
    }
}
