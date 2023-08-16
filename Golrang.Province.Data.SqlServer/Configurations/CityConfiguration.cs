using System.Reflection.Emit;
using Golrang.Province.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Golrang.Province.Data.SqlServer.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.ToTable("ProvinceCity").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.ProvinceId).IsRequired();

            builder.HasOne(x => x.Province).WithMany(x => x.Cities)
                .HasForeignKey(x => x.ProvinceId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
