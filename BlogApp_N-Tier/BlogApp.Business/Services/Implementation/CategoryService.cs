using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Helper;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task Create(CreateCategoryDto createCategoryDto)
        {
            if (!createCategoryDto.LogoImg.CheckContent("image/"))
            {
                throw new Exception("Enter true format");
            }
            Category category = new Category()
            {
                Name = createCategoryDto.Name,
                LogoUrl = createCategoryDto.LogoImg.UploadFile(folderName: "C:\\Users\\Asus\\Desktop\\Task\\BlogApp_N-Tier\\BlogApp.Business\\Staticfiles\\Upload\\")


            };
            await _repo.Create(category);
            _repo.SaveChangeAsync();
        }

        public async Task Delete(int id)
        {
            _repo.Delete(id);
            _repo.SaveChangeAsync();
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return await categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            return await _repo.GetById(id);
        }

      

        public async Task Update(UpdateCategoryDto updateCategoryDto)
        {

            if (updateCategoryDto == null) throw new Exception("Bad Request");

            var existingCategory = await _repo.GetById(updateCategoryDto.Id);
            existingCategory.Name = updateCategoryDto.Name;
            if (updateCategoryDto.LogoImg != null)
            {
                existingCategory.LogoUrl.RemoveFile("C:\\Users\\Asus\\Desktop\\Task\\BlogApp_N-Tier\\BlogApp.Business\\Staticfiles\\Upload\\");
                existingCategory.LogoUrl = updateCategoryDto.LogoImg.UploadFile(folderName: "C:\\Users\\Asus\\Desktop\\Task\\BlogApp_N-Tier\\BlogApp.Business\\Staticfiles\\Upload\\");
            }
            _repo.Update(existingCategory);
            _repo.SaveChangeAsync();
        }
       

        public async Task deleteAll()
        {
            _repo.deleteAll();
            _repo.SaveChangeAsync();
        }
    }
}
