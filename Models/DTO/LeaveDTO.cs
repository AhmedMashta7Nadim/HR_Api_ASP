using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.enum_class;

namespace Models.DTO
{
    public class LeaveDTO
    {
        public Enum_TypeLeave Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IFormFile? File { get; set; }
        public Guid EmployeeId { get; set; }
        public bool IsState { get; set; } = false;

    }
    public class LeaveObject
    {
        public Enum_TypeLeave Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IFormFile? File { get; set; }
        public string EmployeeId { get; set; }
    }
}
