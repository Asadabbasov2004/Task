using Agency.Business.ViewModels.CommonDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.ViewModels.FeatureVm
{
    public class FeatureCreateVm:BaseDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public IFormFile? ImgUrl { get; set; }
    }
}
