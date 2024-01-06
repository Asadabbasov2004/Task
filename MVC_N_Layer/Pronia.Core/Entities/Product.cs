using Pronia.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Core.Entities
{
    public class Product: BaseAudiTableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ProductTag>? ProductTags { get; set; }
        public List<ProductImages>? ProductImages { get; set; }
    }
}
