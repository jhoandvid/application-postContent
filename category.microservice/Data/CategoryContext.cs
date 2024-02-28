using category.microservice.Model;
using Microsoft.EntityFrameworkCore;

namespace category.microservice.Data
{
    public partial class CategoryContext:DbContext
    {

        public CategoryContext() { }

        public CategoryContext(DbContextOptions<CategoryContext> options): base(options) { }


        public virtual DbSet<CategoryModel> Categories { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryContext).Assembly);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder); 

    }
}
