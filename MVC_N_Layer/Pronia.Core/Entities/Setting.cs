using Pronia.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Core.Entities
{
    public class Setting: BaseAudiTableEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
