using LinkMe.Domain;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinkMe.Infrastructure.Mapping
{
    public class DbContext : IdentityDbContext<User>
    {
        //public DbContext()
        //{
        //}

        public DbContext(DbContextOptions<DbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Community> Communities { get; set; }
        public DbSet<Member> Members { get; set; }

        //public DbSet<Administrators> Administrators { get; set; }
    }
}
