using Agency.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Entities
{
    public class Feature:BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string? ImgUrl { get; set; }
    }
}
