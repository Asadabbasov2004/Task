using AutoMapper;
using BlankApp.Business.DTOs.Brand;
using BlankApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp.Business
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<Brand, CreateBrandDto>();
        }
    }
}
