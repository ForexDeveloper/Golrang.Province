using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Golrang.Province.Core.Models;
using Golrang.Province.Core.Models.Enums;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Domain;

namespace Golrang.Province.Data.Models
{
    public class ProvinceEntity : AuditableEntity, IDataEntity<ProvinceEntity, ProvinceModel>, ICloneable
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }

        [Range(100, 1000000)]
        public double Area { get; private set; }

        public bool IsActive { get; private set; }

        [Range(0, 10000000)]
        public int Population { get; private set; }

        [Required]
        public GeoLocation GeoLocation { get; private set; }

        public virtual ObservableCollection<CityEntity> Cities { get; set; } = new NullCollection<CityEntity>();

        public ProvinceEntity()
        {
            
        }

        public ProvinceEntity(string name, double area, bool isActive, int population, GeoLocation geoLocation)
        {
            Name = name;
            Area = area;
            IsActive = isActive;
            Population = population;
            GeoLocation = geoLocation;
        }

        public static ProvinceEntity Create(string name, double area, bool isActive, int population, GeoLocation geoLocation)
        {
            return new ProvinceEntity(name, area, isActive, population, geoLocation);
        }

        public ProvinceModel ToModel(ProvinceModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.Replace(Id, Name, Area, Population, GeoLocation);

            return model;
        }

        public ProvinceEntity FromModel(ProvinceModel model, PrimaryKeyResolvingMap pkMap)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            pkMap.AddPair(model, this);

            Replace(model.Id, model.Name, model.Area, model.Population, model.GeoLocation);

            return this;
        }

        public void Patch(ProvinceEntity target)
        {
            Replace(target.Id, target.Name, target.Area, target.Population, target.GeoLocation);
        }

        public virtual object Clone()
        {
            return (MemberwiseClone() as ProvinceEntity)!;
        }

        private void Replace(string id, string name, double area, int population, GeoLocation geoLocation)
        {
            Id = id;
            Name = name;
            Area = area;
            Population = population;
            GeoLocation = geoLocation;
        }
    }
}
