using System;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.Platform.Core.Common;

namespace Golrang.Province.Core.Models
{
    public sealed class CityModel : AuditableEntity, ICloneable
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(100, 1000000)]
        public double Area { get; set; }

        [Range(0, 10000000)]
        public int Population { get; set; }

        [Required]
        public string ProvinceId { get; set; }

        public void Replace(string id, string name, double area, int population,string provinceId)
        {
            Id = id;
            Name = name;
            Area = area;
            Population = population;
            ProvinceId = provinceId;
        }

        public object Clone()
        {
            return (CityModel)MemberwiseClone();
        }

        public void SetIdentifier()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
