using comment.microservice.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using static Grpc.Core.Metadata;

namespace comment.microservice.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentModel>
    {
        public void Configure(EntityTypeBuilder<CommentModel> entity)
        {

              


            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("content");

            entity.Property(e => e.ContentParentId).HasColumnName("content_parent_id");

            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.PostId).HasColumnName("post_id");

            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            
            entity.HasOne(d => d.ContentParent)
                    .WithMany(p => p.ContentsParents)
                    .HasForeignKey(d => d.ContentParentId);
           
        }
    }
}
