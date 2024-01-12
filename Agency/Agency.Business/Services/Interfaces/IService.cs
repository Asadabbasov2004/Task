using Agency.Business.ViewModels.FeatureVm;
using Agency.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Interfaces
{
    public interface IService
    {
        public Task<List<FeatureGetAllVm>> GetAllAsync();
        public Task<FeatureGetListItemVm> GetByIdAsync(int id);
        public Task CreateAsync(FeatureCreateVm vm);
        public Task UpdateAsync(FeatureUpdateVm vm);
        public Task DeleteAsync(int id);
    }
}
