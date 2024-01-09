﻿using AppBay.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Core.Entities
{
    public class Feature:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }

    }
}
