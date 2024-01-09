using AppBay.Business.ViewModels.Feature;
using AppBay.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.MapperProfile.FeatureProfile
{
    public class FeatureProfile:Profile
    {
        public FeatureProfile()
        {
            CreateMap<FeatureGetVm,Feature>();
            CreateMap<FeatureGetVm,Feature>().ReverseMap();
            CreateMap<FeatureListItemVm,Feature>();
            CreateMap<FeatureListItemVm, Feature>().ReverseMap();
            CreateMap<FeatureCreateVm,Feature>();
            CreateMap<FeatureCreateVm, Feature>().ReverseMap();
            CreateMap<FeatureUpdateVm,Feature>();
            CreateMap<FeatureUpdateVm, Feature>().ReverseMap();
        }
    }
}
