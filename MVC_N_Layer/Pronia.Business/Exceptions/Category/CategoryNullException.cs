using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Exceptions.Category
{
    public class CategoryNullException:Exception
    {
        public CategoryNullException() : base("Bele bir category movcud deyil") { }

        public CategoryNullException(string? message) : base(message)
        {
        }
    }
}
