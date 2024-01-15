using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.Business.ViewModels.BlogVm;
using Temp.Core.Entities;

namespace Temp.Business.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Blog, BlogCreateVm>().ReverseMap();
            CreateMap<Blog, BlogListItemVm>().ReverseMap();
            CreateMap<Blog, BlogGetVm>().ReverseMap();
            CreateMap<Blog, BlogUpdateVm>().ReverseMap();
        }
    }
}
