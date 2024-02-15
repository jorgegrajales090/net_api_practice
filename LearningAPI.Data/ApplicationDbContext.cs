using LearningAPI.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace LearningAPI.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Init one user
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Name = "Jorge Grajales", Email="jorgegrajales090@gmail.com", Password="123456" });


        }
    }
}
