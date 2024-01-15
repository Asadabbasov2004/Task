using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.Business.Service.Interfaces;
using Temp.Business.ViewModels.BlogVm;
using Temp.Core.Entities;
using Temp.DAL.Repository.Interfaces;

namespace Temp.Business.Service.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepsoitory _repsoitory;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepsoitory repsoitory,IMapper mapper)
        {
            _repsoitory = repsoitory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogListItemVm>> GetAllAsync()
        {
          IEnumerable<Blog> entities = await _repsoitory.GetAllAsync();
            List<BlogListItemVm> list = new List<BlogListItemVm>(); 
            foreach (var item in entities)
            {
              BlogListItemVm blogListItem=_mapper.Map<BlogListItemVm>(item);
                list.Add(blogListItem);
            }
            return list;
        }

        public async Task<BlogGetVm> GetByIdAsync(int id)
        {
            var entity = await _repsoitory.GetbyIdAsync(id);
            return _mapper.Map<BlogGetVm>(entity);
        }
        public async Task CreateAsync(BlogCreateVm blogCreateVm)
        {
            var entity = _mapper.Map<Blog>(blogCreateVm);
            await _repsoitory.CreateAsync(entity);
            await _repsoitory.SaveChangeAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repsoitory.Table.FirstOrDefaultAsync(x => x.Id == id);
             _repsoitory.DeleteAsync(entity);
            await _repsoitory.SaveChangeAsync();
        }

        

        public async Task UpdateAsync(BlogUpdateVm blogUpdateVm)
        {
            var entity = _mapper.Map<Blog>(blogUpdateVm);
            _repsoitory.UpdateAsync(entity);
            await _repsoitory.SaveChangeAsync();
         }
    }
}
