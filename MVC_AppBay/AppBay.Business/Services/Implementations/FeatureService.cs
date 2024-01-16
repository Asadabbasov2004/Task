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
        private readonly IMapper _mapper;
        private readonly IFeatureRepository _repository;

        public FeatureService(IMapper mapper, IFeatureRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<IEnumerable<Feature>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Feature> GetAsync(int id)
        {
            var entity =await _repository.GetByIdAsync(id);
            return entity;
        }

        public Task CreateAsync(FeatureCreateVm featureCreateVm)
        {

        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task UpdateAsync(FeatureUpdateVm featureUpdateVm)
        {
            throw new NotImplementedException();
        }
    }
}
