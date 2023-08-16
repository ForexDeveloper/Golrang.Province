using Golrang.Province.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Golrang.Province.Data.SqlServer
{
    public class SqlServerDbContextFactory : IDesignTimeDbContextFactory<ProvinceDbContext>
    {
        private const string ModuleConnectionString =
            "Data Source=(local);Initial Catalog=Golrang;Persist Security Info=True;User ID=sa;Password=P@ssw0rdP@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=30";

        private const string PlatformConnectionString =
            "Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=sa;Password=P@ssw0rdP@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=30";

        public ProvinceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProvinceDbContext>();
            var connectionString = args.Any() ? args[0] : PlatformConnectionString;

            builder.UseSqlServer(connectionString, db => db.MigrationsAssembly(typeof(SqlServerDbContextFactory).Assembly.GetName().Name));

            return new ProvinceDbContext(builder.Options);
        }
    }
}
