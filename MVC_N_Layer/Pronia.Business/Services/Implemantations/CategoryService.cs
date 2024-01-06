using AutoMapper;
using Pronia.Business.DTOs.CategoryDtos;
using Pronia.Business.Exceptions.Category;
using Pronia.Business.Exceptions.Common;
using Pronia.Business.Services.Interface;
using Pronia.Core.Entities;
using Pronia.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.CategoryDtos;

namespace Pronia.Business.Services.Implemantations
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ICollection<CategoryListitemDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return _mapper.Map<ICollection<CategoryListitemDto>>(categories);
        }

        public async Task<bool> CreateAsync(CategoryCreateDto createDto)
        {
            if (createDto == null) throw new CategoryNullException();
            //Category category = new Category()
            //{
            //    Title = createDto.Title,
            //    ParentCategoryId = createDto.ParentCategoryId,
            //    CreatedAt = createDto.CreatedAt,

            //};
            if (createDto.ParentCategoryId != null)
            {
                var a = await _repo.FindByIdAsync(createDto.ParentCategoryId);
                if (a == null)
                {
                    throw new CategoryNullException();
                };
            }
            var category = _mapper.Map<Category>(createDto);
            await _repo.CreateAsync(category);
            int result = await _repo.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }


        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            await CheckEntity(id);
            return _mapper.Map<CategoryGetDto>(await _repo.FindByIdAsync(id));
        }

        public async Task<bool> UpdateAsync(CategoryUpdateDto updateDto)
        {
            await CheckEntity(updateDto.Id);

            Category category = await _repo.FindByIdAsync(updateDto.Id);
            _mapper.Map(updateDto, category);
            var result = await _repo.SaveChangesAsync();
            if (result > 0) return true;
            return false;
        }
        public async Task CheckEntity(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            if (!await _repo.IsExist(id)) throw new CategoryNotFoundException();
        }
        public async Task Remove(int id)
        {
            await CheckEntity(id);
            await _repo.Remove(id);
            await _repo.SaveChangesAsync();
        }
    }
}
