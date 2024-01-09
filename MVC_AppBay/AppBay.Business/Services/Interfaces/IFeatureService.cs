using AppBay.Business.ViewModels.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.Services.Interfaces
{
    public interface IFeatureService
    {
        Task<List<FeatureGetVm>> GetAllAsync();
        Task<FeatureListItemVm> GetByIdAsync(int id);
        void Create(FeatureCreateVm entity);
        void Update(FeatureUpdateVm entity);
        Task Delete(int id);
    }
}
