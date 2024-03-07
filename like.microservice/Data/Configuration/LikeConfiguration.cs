using like.microservice.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace like.microservice.Data.Configuration
{
    public class LikeConfiguration : IEntityTypeConfiguration<LikeModel>
    {
        public void Configure(EntityTypeBuilder<LikeModel> entity)
        {
            
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.ContentType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("content_type");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
           
        }
    }
}
