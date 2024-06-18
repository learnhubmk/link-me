using LinkMe.Infrastructure.Mapping;

using Microsoft.EntityFrameworkCore;

namespace LinkMe.Infrastructure.SqlServer
{
    public class LinkMeSqlServerDbContext : LinkMeDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //Debugger.Break();

            string connectionString = Environment.GetEnvironmentVariable("SqlConnection");//?? "Data Source=linkme.db";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
