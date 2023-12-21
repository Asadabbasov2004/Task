using AutoMapper;
namespace Second_Api
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateCategoryDto,Category>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<UpdateCategoryDtos, Category>();
            CreateMap<Category, UpdateCategoryDtos>();

        }
    }
}
