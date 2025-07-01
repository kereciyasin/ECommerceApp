using ECommerceApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public interface IFeatureService
    {
        Task<IEnumerable<Feature>> GetAllAsync();
        Task<Feature> GetByIdAsync(int id);
        Task AddAsync(Feature feature);
        Task UpdateAsync(Feature feature);
        Task DeleteAsync(int id);
    }
}
