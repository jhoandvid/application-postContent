using Microsoft.EntityFrameworkCore;
using Post.Microservice.Model;

namespace User.microservice.Data
{
    public partial class PostContext: DbContext
    {
        public PostContext(DbContextOptions<PostContext> options): base(options)
        {

        }

        public virtual DbSet<PostModel> Posts { get; set; } = null!;
        public virtual DbSet<PostCategoryModel> PostCategories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostContext).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
