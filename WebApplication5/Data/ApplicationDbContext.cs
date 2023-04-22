using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Base> Bases { get; set; }
        public DbSet<Sub> Subs { get; set; }
        public DbSet<OtherBase> OtherBases { get; set; }
        public DbSet<OtherSub> OtherSubs { get; set; }
    }
}