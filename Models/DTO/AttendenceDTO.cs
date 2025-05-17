using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class AttendenceDTO
    {
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
