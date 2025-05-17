using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;

namespace Models.Model
{
    public class Attendence: EntityClass //الحضور والانصراف 
    {
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public Guid EmployeeId { get; set; }
        [NotMapped]
        public Employee? Employee { get; set; }

    }
}
