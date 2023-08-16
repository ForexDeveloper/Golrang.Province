using System;
using System.ComponentModel.DataAnnotations;
using Golrang.Province.Core.Models;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Domain;

namespace Golrang.Province.Data.Models
{
    public class CityEntity : AuditableEntity, IDataEntity<CityEntity, CityModel>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }

        [Range(100, 1000000)]
        public double Area { get; private set; }

        [Range(0, 10000000)]
        public int Population { get; private set; }

        public string ProvinceId { get; private set; }

        public virtual ProvinceEntity Province { get; private set; }

        public CityEntity()
        {

        }

        public CityEntity(string name, double area, int population, string provinceId)
        {
            Name = name;
            Area = area;
            Population = population;
            ProvinceId = provinceId;
        }

        public static CityEntity Create(string name, double area, int population, string provinceId)
        {
            return new CityEntity(name, area, population, provinceId);
        }

        public CityModel ToModel(CityModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.Replace(Id, Name, Area, Population, ProvinceId);

            return model;
        }

        public CityEntity FromModel(CityModel model, PrimaryKeyResolvingMap pkMap)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            pkMap.AddPair(model, this);

            Replace(model.Id, model.Name, model.Area, model.Population, model.ProvinceId);

            return this;
        }

        public void Patch(CityEntity target)
        {
            Replace(target.Id, target.Name, target.Area, target.Population, target.ProvinceId);
        }

        private void Replace(string id, string name, double area, int population, string provinceId)
        {
            Id = id;
            Name = name;
            Area = area;
            Population = population;
            ProvinceId = provinceId;
        }
    }
}
