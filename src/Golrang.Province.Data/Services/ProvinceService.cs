using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Golrang.Province.Core.Events;
using Golrang.Province.Core.Models;
using Golrang.Province.Core.Services;
using Golrang.Province.Data.Models;
using Golrang.Province.Data.Repositories;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Events;
using VirtoCommerce.Platform.Data.GenericCrud;

namespace Golrang.Province.Data.Services
{
    public sealed class ProvinceService : CrudService<ProvinceModel, ProvinceEntity, ProvinceChangeEvent, ProvinceChangedEvent>, IProvinceService
    {
        private readonly Func<IProvinceRepository> _repositoryFactory;
        private readonly IPlatformMemoryCache _platformMemoryCache;
        private readonly IEventPublisher _eventPublisher;

        public ProvinceService(Func<IProvinceRepository> repositoryFactory, IPlatformMemoryCache platformMemoryCache, IEventPublisher eventPublisher) : base(repositoryFactory, platformMemoryCache, eventPublisher)
        {
            _repositoryFactory = repositoryFactory;
            _platformMemoryCache = platformMemoryCache;
            _eventPublisher = eventPublisher;
        }

        protected override Task<IList<ProvinceEntity>> LoadEntities(IRepository repository, IList<string> ids, string responseGroup)
        {
            return ((IProvinceRepository)repository).GetProvincesByIdsAsync(ids);
        }

        public override Task SaveChangesAsync(IList<ProvinceModel> models)
        {
            return base.SaveChangesAsync(models);
        }

        public async Task<IList<ProvinceModel>> GetAllProvinces(IList<string> ids)
        {
            var provinces = await _repositoryFactory().GetProvincesByIdsAsync(ids);

            return provinces.Select(province => province.ToModel(new ProvinceModel())).ToList();
        }
    }
}
