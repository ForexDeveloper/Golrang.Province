using System.Collections.Generic;
using System.Threading.Tasks;
using Golrang.Province.Core.Models;
using VirtoCommerce.Platform.Core.GenericCrud;

namespace Golrang.Province.Core.Services
{
    public interface ICityService : ICrudService<CityModel>
    {
        Task<CityModel> GetCityByProvinceId(string provinceId);
    }
}
