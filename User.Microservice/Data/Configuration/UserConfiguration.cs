using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using post.microservice.models;

namespace User.microservice.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> entity)
        {
            entity.ToTable("Users");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            /*
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at")
                .HasDefaultValueSql("(getdate())");
            */
            entity.Property(e => e.Email).HasColumnName("email");

            entity.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Name).HasColumnName("name");

            entity.Property(e => e.Password).HasColumnName("password");

            entity.Property(e => e.Role)
                .HasColumnName("role")
                .HasDefaultValueSql("('user')");
        }
    }
}
