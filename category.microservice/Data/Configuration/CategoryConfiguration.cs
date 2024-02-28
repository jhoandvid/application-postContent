using category.microservice.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace category.microservice.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        }
    }
}
