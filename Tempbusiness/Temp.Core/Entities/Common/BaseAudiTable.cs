using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp.Core.Entities.Common
{
    public abstract class BaseAudiTable:BaseEntity
    {
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
       public bool IsDeleted { get; set; }=false;
    }
}
