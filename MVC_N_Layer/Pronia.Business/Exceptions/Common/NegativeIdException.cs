using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Exceptions.Common
{
    public class NegativeIdException:Exception
    {
        public NegativeIdException() : base("Bele bir category movcud deyil") { }

        public NegativeIdException(string? message) : base(message)
        {
        }
    }
}
