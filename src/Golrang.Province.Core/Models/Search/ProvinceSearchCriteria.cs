using Golrang.Province.Core.Models.Enums;
using VirtoCommerce.Platform.Core.Common;

namespace Golrang.Province.Core.Models.Search
{
    public sealed class ProvinceSearchCriteria : SearchCriteriaBase
    {
        public string Name { get; set; }

        public double? Area { get; set; }

        public bool? IsActive { get; set; }

        public int? Population { get; set; }

        public GeoLocation? GeoLocation { get; set; }
    }
}
