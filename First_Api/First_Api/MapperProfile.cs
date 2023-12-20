using AutoMapper;
using First_Api.DTOs.BrandDTOs;
using First_Api.Entities;

namespace First_Api
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateBrandDto,Brand>();
            CreateMap<Brand, CreateBrandDto>();
        }
    }
}
