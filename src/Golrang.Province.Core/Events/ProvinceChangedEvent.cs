using System.Collections.Generic;
using Golrang.Province.Core.Models;
using VirtoCommerce.Platform.Core.Events;

namespace Golrang.Province.Core.Events
{
    public sealed class ProvinceChangedEvent : GenericChangedEntryEvent<ProvinceModel>
    {
        public ProvinceChangedEvent(IEnumerable<GenericChangedEntry<ProvinceModel>> changedEntries) : base(changedEntries)
        {
        }
    }
}
