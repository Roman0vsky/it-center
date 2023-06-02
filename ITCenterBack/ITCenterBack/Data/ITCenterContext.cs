using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITCenterBack.Models;
using ITCenterBack.Constants;

namespace ITCenterBack.Data
{
    public class ITCenterContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
		
		public DbSet<Course> Courses { get; set; }
        public DbSet<News> News { get; set; } 
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<AvaliableTime> AvaliableTimes { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<CourseApplication> CourseApplications { get; set; }
		public DbSet<ApplicationTime> ApplicationTimes { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
		public DbSet<Info> Info { get; set; }

		public ITCenterContext(DbContextOptions<ITCenterContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = AccountRoles.Roles;
            builder.Entity<IdentityRole<long>>().HasData(roles);

			DataSeed.Seed(builder);
		}
    }
}
