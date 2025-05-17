using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entitys
{
    public class EntityClass : EntityInterface
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;

        public EntityClass()
        {
            Id = Guid.NewGuid();
        }

    }
}
