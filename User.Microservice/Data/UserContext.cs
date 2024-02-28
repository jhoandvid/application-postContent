using Microsoft.EntityFrameworkCore;
using post.microservice.models;

namespace User.microservice.Data
{
    public partial class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {

        }

        public virtual DbSet<UserModel> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
