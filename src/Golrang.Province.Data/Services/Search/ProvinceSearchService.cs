using System;
using System.Linq;
using Golrang.Province.Core.Models;
using Golrang.Province.Core.Models.Search;
using Golrang.Province.Core.Services;
using Golrang.Province.Core.Services.Search;
using Golrang.Province.Data.Models;
using Golrang.Province.Data.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Options;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.GenericCrud;
using VirtoCommerce.Platform.Data.GenericCrud;

namespace Golrang.Province.Data.Services.Search
{
    public class ProvinceSearchService : SearchService<ProvinceSearchCriteria, ProvinceSearchResult, ProvinceModel, ProvinceEntity>, IProvinceSearchService
    {
        public ProvinceSearchService(Func<IProvinceRepository> repositoryFactory, IPlatformMemoryCache platformMemoryCache, IProvinceService crudService, IOptions<CrudOptions> crudOptions) : base(repositoryFactory, platformMemoryCache, crudService, crudOptions)
        {
        }

        protected override IQueryable<ProvinceEntity> BuildQuery(IRepository repository, ProvinceSearchCriteria criteria)
        {
            var query = ((IProvinceRepository)repository).Provinces;

            //if (criteria.IsActive.HasValue)
            //{
            //    query = query.Where(p => p.IsActive == criteria.IsActive.Value);
            //}

            //if (criteria.Area.HasValue)
            //{
            //    query = query.Where(p => p.Area >= criteria.Area.Value);
            //}

            //if (criteria.GeoLocation.HasValue)
            //{
            //    query = query.Where(p => p.GeoLocation == criteria.GeoLocation);
            //}

            if (!string.IsNullOrWhiteSpace(criteria.Name))
            {
                query = query.Where(p => p.Name == criteria.Name);
            }

            return query;
        }
    }
}
