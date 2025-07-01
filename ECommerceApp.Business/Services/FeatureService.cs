using ECommerceApp.Data.Repositories;
using ECommerceApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IRepository<Feature> _featureRepository;

        public FeatureService(IRepository<Feature> featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<IEnumerable<Feature>> GetAllAsync()
        {
            return await _featureRepository.GetAllAsync();
        }

        public async Task<Feature> GetByIdAsync(int id)
        {
            return await _featureRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Feature feature)
        {
            await _featureRepository.AddAsync(feature);
            await _featureRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Feature feature)
        {
            _featureRepository.Update(feature);
            await _featureRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var feature = await _featureRepository.GetByIdAsync(id);
            if (feature != null)
            {
                _featureRepository.Delete(feature);
                await _featureRepository.SaveChangesAsync();
            }
        }
    }
}
