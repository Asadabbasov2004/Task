using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.Business.Helpers;
using Temp.Business.Service.Interfaces;
using Temp.Business.ViewModels.BlogVm;
using Temp.Core.Entities;
using Temp.DAL.Repository.Interfaces;

namespace Temp.Business.Service.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepsoitory _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public BlogService(IBlogRepsoitory repsoitory,IMapper mapper, IWebHostEnvironment environment)
        {
            _repository = repsoitory;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task CreateAsync(BlogCreateVm blogCreateVm)
        {
            Blog blog = _mapper.Map<Blog>(blogCreateVm);
            string ImageUrl = await blogCreateVm.Url.UploadFile(_environment.WebRootPath, "Upload");
            blog.Url = ImageUrl;
            await _repository.CreateAsync(blog);
            await _repository.SaveChangeAsync();

        }

        public async Task Delete(int id)
        {
            Blog blog = await _repository.GetbyIdAsync(id);
            _repository.Delete(blog);
            await _repository.SaveChangeAsync();

        }

        public async Task<IEnumerable<BlogListItemVm>> GetAllAsync()
        {
            IList<BlogListItemVm> ListAll;
            var GetAll = await _repository.GetAllAsync();
            foreach (var item in GetAll)
            {
                ListAll.Add(_mapper.Map<BlogListItemVm>(item));
            }
            return ListAll;
        }

        public async Task<BlogGetVm> GetByIdAsync(int id)
        {
            throw new NotImplementedException();

        }

        public Task UpdateAsync(BlogUpdateVm blogUpdateVm)
        {
            throw new NotImplementedException();
        }
    }
}
