using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITCenterBack.Models;

namespace ITCenterBack.Data
{
    //to do
    public class ITCenterContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<News> News { get; set; } 

        public ITCenterContext(DbContextOptions<ITCenterContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    DataSeed.Seed(builder);

        //    base.OnModelCreating(builder);

        //    //var roles = AccountsRoles.Roles;

        //    //builder.Entity<IdentityRole<Guid>>().HasData(roles);
        //}
    }
}
