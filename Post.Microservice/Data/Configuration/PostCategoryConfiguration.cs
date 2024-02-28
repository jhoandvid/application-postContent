using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Microservice.Model;

namespace User.microservice.Data.Configuration
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategoryModel>
    {
        public void Configure(EntityTypeBuilder<PostCategoryModel> entity)
        {
            entity.ToTable("PostCategories");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");

            entity.Property(e => e.IdPost).HasColumnName("id_post");

             entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.PostCategories)
                    .HasForeignKey(d => d.IdPost)
                    .HasConstraintName("FK__PostCateg__id_po__619B8048");

        }
    }
}