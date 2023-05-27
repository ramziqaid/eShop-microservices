using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Common
{
    public abstract class EntityBase
    {
    }
    public abstract class EntityBase<T>: EntityBase
    {
        public T Id { get;protected set; } 
        
    }    
    public abstract class EntityCreation<T>: EntityBase<T>
    { 
        public string CreatedBy { get;  set; }
        public DateTime CreatedDate { get;  set; }
        
    } 
    public abstract class EntityAudit<T>: EntityCreation<T>
    { 
        public string? ModifiedBy { get;  set; }
        public DateTime? ModifiedDate { get;  set; }
    }
}
