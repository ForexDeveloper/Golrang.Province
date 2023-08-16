using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golrang.Province.Core.Models.Enums;
using Golrang.Province.Data.Models;
using Microsoft.EntityFrameworkCore;
using VirtoCommerce.Platform.Core.Domain;
using VirtoCommerce.Platform.Core.Extensions;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace Golrang.Province.Data.Repositories
{
    public sealed class ProvinceRepository : DbContextRepositoryBase<ProvinceDbContext>, IProvinceRepository
    {
        public ProvinceRepository(ProvinceDbContext dbContext, IUnitOfWork unitOfWork = null) : base(dbContext, unitOfWork)
        {
        }

        public IQueryable<CityEntity> Cities => DbContext.Set<CityEntity>();

        public IQueryable<ProvinceEntity> Provinces => DbContext.Set<ProvinceEntity>();

        public async Task<IList<ProvinceEntity>> GetProvincesByIdsAsync(IList<string> ids)
        {
            return await Provinces.Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public async Task<IList<CityEntity>> GetCitiesByIdsAsync(IList<string> ids)
        {
            return await Cities.Where(p => ids.Contains(p.Id)).ToListAsync();
        }
    }
}
