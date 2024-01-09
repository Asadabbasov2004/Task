using AppBay.Business.Services.Interfaces;
using AppBay.Business.ViewModels.Feature;
using AppBay.Core.Entities;
using AppBay.DAL.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _repo;
        private readonly IMapper _mapper;

        public FeatureService(IFeatureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async void Create(FeatureCreateVm vm)
        {
            Feature entity = new Feature();
            var feature= _mapper.Map<Feature>(vm);
            await _repo.CreateAsync(feature);
            await _repo.SaveChangeAsync();
            
        }

        public async Task Delete(int id)
        {
           
        }

        public Task<List<FeatureGetVm>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FeatureListItemVm> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(FeatureUpdateVm entity)
        {
            throw new NotImplementedException();
        }
    }
}
