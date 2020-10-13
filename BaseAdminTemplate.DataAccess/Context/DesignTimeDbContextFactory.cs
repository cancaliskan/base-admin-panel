using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using BaseAdminTemplate.DataAccess.Helpers;

namespace BaseAdminTemplate.DataAccess.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = ConfigurationParameterHelper.GetConfigurationParameter("DefaultConnection");
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}