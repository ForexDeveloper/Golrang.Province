using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golrang.Province.Data.Models;
using VirtoCommerce.Platform.Core.Common;

namespace Golrang.Province.Data.Repositories
{
    public interface IProvinceRepository : IRepository
    {
        IQueryable<CityEntity> Cities { get; }

        IQueryable<ProvinceEntity> Provinces { get; }

        Task<IList<ProvinceEntity>> GetProvincesByIdsAsync(IList<string> ids);

        Task<IList<CityEntity>> GetCitiesByIdsAsync(IList<string> ids);
    }
}
