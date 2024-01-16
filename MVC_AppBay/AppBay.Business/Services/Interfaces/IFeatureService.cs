using AppBay.Business.ViewModels.Feature;
using AppBay.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.Services.Interfaces
{
    public interface IFeatureService
    {
        public Task<IEnumerable<Feature>> GetAllAsync();
        public Task<Feature> GetAsync(int id);
        public Task CreateAsync(FeatureCreateVm featureCreateVm);
        public Task UpdateAsync(FeatureUpdateVm featureUpdateVm);
        public Task DeleteAsync(int id);

    }
}
