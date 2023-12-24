using AutoMapper;
using Second_Api.Repostories.Abstraction;
using Second_Api.Services.Interfaces;

namespace Second_Api.Services.Implementation
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository brandRepository, IMapper mapper)
        {
            _repository = brandRepository;
            _mapper = mapper;
        }



        public async Task<IQueryable<Category>> GetAll()
        {
            return await _repository.GetAll(orderbyExpression: c => c.Name, isDescending: true);
        }

        public async Task<Category> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            var brand = await _repository.GetById(id);
            if (brand == null) throw new Exception("Not Found");
            return brand;
        }
        public async Task<Category> Create(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null) throw new Exception("Not null");
            Category category = _mapper.Map<Category>(createCategoryDto);
            await _repository.Create(category);
            await _repository.SaveChangeAsync();
            return category;
        }

        public async Task<Category> Update(int id, UpdateCategoryDtos updateCategoryDtos)
        {
            if (id <= 0)  throw new Exception("Bad request");
            Category existCategory = await _repository.GetById(id);
            if (existCategory == null) throw new Exception("Not Found");
            _mapper.Map(updateCategoryDtos,existCategory);
            _repository.Update(existCategory);
            await _repository.SaveChangeAsync();
            return existCategory;   
        }

        public async Task<Category> Delete(int id)
        {
            Category oldCategory = await _repository.GetById(id);
            if(oldCategory != null)
            {
                _repository.Delete(oldCategory);
            }
            else
            {
                throw new Exception("Not found");
            }
            await _repository.SaveChangeAsync();
            return oldCategory;
        }
    }
}
