using System.Collections.Generic;
using Golrang.Province.Core.Models;
using VirtoCommerce.Platform.Core.Events;

namespace Golrang.Province.Core.Events
{
    public sealed class ProvinceChangeEvent : GenericChangedEntryEvent<ProvinceModel>
    {
        public ProvinceChangeEvent(IEnumerable<GenericChangedEntry<ProvinceModel>> changedEntries) : base(changedEntries)
        {
        }
    }
}
