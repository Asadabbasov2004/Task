﻿using First_Api.Entities.Base;

namespace First_Api.Entities
{
    public class Brand:BaseEntity
    {
    
        public string Name { get; set; }
        public List<Car>? Cars { get; set; }

    }
}
