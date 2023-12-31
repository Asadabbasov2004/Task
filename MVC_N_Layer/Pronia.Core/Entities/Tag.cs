﻿using Pronia.Core.Entities.Common;

namespace Pronia.Core.Entities
{
    public class Tag: BaseAudiTableEntity
    {
        public string Name { get; set; } = "DefaultName";
        public List<ProductTag>? productTags { get; set; }
    }
}