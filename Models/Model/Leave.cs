using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.Entitys;
using Models.enum_class;

namespace Models.Model
{
    public class Leave:EntityClass 
    {
        public Enum_TypeLeave Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AllDates_e
        {
            get
            {
                return (EndDate - StartDate).Days;
            }
            set
            {

            }
        }
        public bool IsState { get; set; } = false;
        public string? Path { get; set; }
        [NotMapped] 
        public IFormFile? File { get; set; }
        public Guid EmployeeId { get; set; }
        [NotMapped]
        public Employee? Employee { get; set; }

    }
}
