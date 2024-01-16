using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.Business.ViewModels.BlogVm;
using Temp.Core.Entities;

namespace Temp.Business.Service.Interfaces
{
    public interface IBlogService
    {
        public Task<IEnumerable<BlogListItemVm>> GetAllAsync();
        public Task<BlogGetVm> GetByIdAsync(int id);
        public Task CreateAsync(BlogCreateVm blogCreateVm);
        public Task UpdateAsync(BlogUpdateVm blogUpdateVm);
        public Task Delete(int id);
    }
}
