﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp.Business.ViewModels.BlogVm
{
    public class BlogCreateVm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Url { get; set; }
    }
}
