using Pronia.Core.Entities.Common;

namespace Pronia.Core.Entities
{
    public class ProductTag: BaseAudiTableEntity
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}