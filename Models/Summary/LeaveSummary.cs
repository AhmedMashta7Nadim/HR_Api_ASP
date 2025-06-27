using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.Entitys;
using Models.enum_class;

namespace Models.Summary
{
    public class LeaveSummary:EntityClass
    {
        public Enum_TypeLeave Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsState { get; set; }
        public string? Path { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
