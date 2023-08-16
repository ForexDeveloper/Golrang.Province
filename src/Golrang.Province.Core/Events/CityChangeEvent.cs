using System.Collections.Generic;
using Golrang.Province.Core.Models;
using VirtoCommerce.Platform.Core.Events;

namespace Golrang.Province.Core.Events
{
    public sealed class CityChangeEvent : GenericChangedEntryEvent<CityModel>
    {
        public CityChangeEvent(IEnumerable<GenericChangedEntry<CityModel>> changedEntries) : base(changedEntries)
        {
        }
    }
}
