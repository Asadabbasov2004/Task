﻿using AppBay.Business.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.ViewModels.Feature
{
    public class FeatureListItemVm:BaseAudiTableDto
    {
        public string Title { get; set; }
        public string IconName { get; set; }
    }
}