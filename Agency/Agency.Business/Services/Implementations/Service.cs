using Agency.Business.Services.Interfaces;
using Agency.Business.ViewModels.FeatureVm;
using Agency.Core.Entities;
using Agency.DAL.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Implementations
{
    public class Service : IService
    {
        private readonly IFeature _feature;
        private readonly IMapper _mapper;

        public Service(IFeature feature,IMapper mapper)
        {
          _feature = feature;
            _mapper= mapper;
        }


        public async Task CreateAsync(FeatureCreateVm vm)
        {
            if (vm == null) throw new NotImplementedException();
            var entity = _mapper.Map<Feature>(vm);
            await _feature.CreateAync(entity);
            await _feature.SavechangesAsync();
        }

        public async Task<List<FeatureGetAllVm>> GetAllAsync()
        {
            var entities = await _feature.GetAllAsync();
            List<FeatureGetAllVm> list;
            foreach(var item in entities)
            {

            }
            throw new Exception();
        }

        public async Task DeleteAsync(int id)
        {
            Feature feature = await  _feature.GetByIdAsync(id);
            if (feature is not null) throw new NotImplementedException();
            await _feature.DeleteAync(feature.Id);
            await _feature.SavechangesAsync();
        }

        public async Task<FeatureGetListItemVm> GetByIdAsync(int id)
        {
           var a = await _feature.GetByIdAsync(id);
            return _mapper.Map<FeatureGetListItemVm>(a);
        }

        public async Task UpdateAsync(FeatureUpdateVm vm)
        {
            if(vm is not null) throw new Exception();
            var a = await _feature.GetByIdAsync(vm.Id);
            _feature.UpdateAync(a);
            await _feature.SavechangesAsync();
        }


    }
}
