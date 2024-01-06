using Pronia.Core.Entities.Common;

namespace Pronia.Core.Entities
{
    public class ProductImages: BaseAudiTableEntity
    {
        public string Url { get; set; }
        public bool? IsPrime { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}