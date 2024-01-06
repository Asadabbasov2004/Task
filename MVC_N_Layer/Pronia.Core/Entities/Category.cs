using Pronia.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Core.Entities
{
    public class Category:BaseAudiTableEntity
    {
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}