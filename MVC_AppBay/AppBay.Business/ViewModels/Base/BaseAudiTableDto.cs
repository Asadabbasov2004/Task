using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.ViewModels.Base
{
    public abstract class BaseAudiTableDto:BaseDto
    {
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
