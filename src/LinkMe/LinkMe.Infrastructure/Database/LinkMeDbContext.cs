using LinkMe.Domain;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinkMe.Infrastructure.Mapping
{
    public class LinkMeDbContext : IdentityDbContext<User>
    {
        public LinkMeDbContext()
        {
                
        }

        public LinkMeDbContext(DbContextOptions<LinkMeDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        
        // TODO Add admins
        //public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<Community> Communities { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
