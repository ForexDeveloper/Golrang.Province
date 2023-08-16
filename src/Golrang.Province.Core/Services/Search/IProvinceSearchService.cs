using Golrang.Province.Core.Models;
using Golrang.Province.Core.Models.Search;
using VirtoCommerce.Platform.Core.GenericCrud;

namespace Golrang.Province.Core.Services.Search
{
    public interface IProvinceSearchService : ISearchService<ProvinceSearchCriteria, ProvinceSearchResult, ProvinceModel>
    {
    }
}
