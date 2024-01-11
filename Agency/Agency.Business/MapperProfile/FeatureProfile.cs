using Agency.Business.ViewModels.FeatureVm;
using Agency.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.MapperProfile
{
    public class FeatureProfile:Profile
    {

        public FeatureProfile()
        {
            CreateMap<Feature,FeatureCreateVm>().ReverseMap();
            CreateMap<Feature,FeatureGetAllVm>().ReverseMap();
            CreateMap<Feature,FeatureGetListItemVm>().ReverseMap();
            CreateMap<Feature,FeatureUpdateVm>().ReverseMap();

        }
    }
}
