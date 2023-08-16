using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golrang.Province.Core.Events;
using Golrang.Province.Core.Models;
using Golrang.Province.Core.Services;
using Golrang.Province.Data.Models;
using Golrang.Province.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Events;
using VirtoCommerce.Platform.Data.GenericCrud;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace Golrang.Province.Data.Services
{
    public sealed class CityService : CrudService<CityModel, CityEntity, CityChangeEvent, CityChangedEvent>, ICityService
    {
        private readonly Func<IProvinceRepository> _repositoryFactory;

        public CityService(Func<IProvinceRepository> repositoryFactory, IPlatformMemoryCache platformMemoryCache, IEventPublisher eventPublisher) : base(repositoryFactory, platformMemoryCache, eventPublisher)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<CityModel> GetCityByProvinceId(string provinceId)
        {
            using var repository = _repositoryFactory();
            repository.DisableChangesTracking();

            var cityEntity = await repository.Cities.Where(p => p.ProvinceId == provinceId).FirstOrDefaultAsync();

            var city = cityEntity.ToModel(AbstractTypeFactory<CityModel>.TryCreateInstance());

            return city;
        }

        protected override Task<IList<CityEntity>> LoadEntities(IRepository repository, IList<string> ids, string responseGroup)
        {
            return ((IProvinceRepository)repository).GetCitiesByIdsAsync(ids);
        }
    }
}
