using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Microservice.Model;

namespace User.microservice.Data.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<PostModel>
    {
        public void Configure(EntityTypeBuilder<PostModel> entity)
        {
            entity.ToTable("Posts");
            entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("content");
            /*
                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");
            */
                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("title");
            /*
                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");
            */
        }
    }
}
