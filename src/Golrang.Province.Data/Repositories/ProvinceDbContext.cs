using EntityFrameworkCore.Triggers;
using Golrang.Province.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Golrang.Province.Data.Repositories;

public class ProvinceDbContext : DbContextWithTriggers
{
    public ProvinceDbContext(DbContextOptions<ProvinceDbContext> options)
        : base(options)
    {
    }

    protected ProvinceDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Province

        modelBuilder.Entity<ProvinceEntity>().ToTable("Province").HasKey(x => x.Id);
        modelBuilder.Entity<ProvinceEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
        modelBuilder.Entity<ProvinceEntity>().Property(x => x.Name).HasMaxLength(1000).IsRequired();
        modelBuilder.Entity<ProvinceEntity>().Property(x => x.GeoLocation).IsRequired();

        #endregion

        #region City

        modelBuilder.Entity<CityEntity>().ToTable("ProvinceCity").HasKey(x => x.Id);
        modelBuilder.Entity<CityEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
        modelBuilder.Entity<CityEntity>().Property(x => x.Name).HasMaxLength(1000).IsRequired();
        modelBuilder.Entity<CityEntity>().Property(x => x.ProvinceId).IsRequired();

        modelBuilder.Entity<CityEntity>().HasOne(x => x.Province).WithMany(x => x.Cities)
            .HasForeignKey(x => x.ProvinceId).OnDelete(DeleteBehavior.Cascade);

        #endregion

        base.OnModelCreating(modelBuilder);
    }
}
