using Golrang.Province.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Golrang.Province.Data.SqlServer.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<ProvinceEntity>
    {
        public void Configure(EntityTypeBuilder<ProvinceEntity> builder)
        {
            builder.ToTable("Province").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.GeoLocation).IsRequired();
        }
    }
}
