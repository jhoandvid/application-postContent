using like.microservice.Model;
using Microsoft.EntityFrameworkCore;

namespace like.microservice.Data
{
    public partial class LikeContext: DbContext
    {
        public LikeContext()
        {
        }

        public LikeContext(DbContextOptions<LikeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LikeModel> Likes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LikeContext).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
