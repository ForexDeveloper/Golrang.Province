using System;
using Golrang.Province.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.Platform.Core.Common;

namespace Golrang.Province.Core.Models
{
    public sealed class ProvinceModel : AuditableEntity, ICloneable
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(100, 1000000)]
        public double Area { get; set; }

        public bool IsActive { get; set; }

        [Range(0, 10000000)]
        public int Population { get; set; }

        [Required]
        public GeoLocation GeoLocation { get; set; }

        public void Replace(string id, string name, double area, int population, GeoLocation geoLocation)
        {
            Id = id;
            Name = name;
            Area = area;
            Population = population;
            GeoLocation = geoLocation;
        }

        public object Clone()
        {
            return (ProvinceModel)MemberwiseClone();
        }

        public void SetIdentifier()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
