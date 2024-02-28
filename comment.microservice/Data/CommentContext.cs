using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using comment.microservice.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static Grpc.Core.Metadata;

namespace comment.microservice.Data
{
    public partial class CommentContext : DbContext
    {
        public CommentContext()
        {
        }

        public CommentContext(DbContextOptions<CommentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommentModel> Comments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentContext).Assembly);
            modelBuilder
             .Entity<CommentModel>()
             .HasOne(c => c.ContentParent)
             .WithMany(c => c.ContentsParents)
             .HasForeignKey(c=>c.ContentParentId)
             .OnDelete(DeleteBehavior.Cascade);

            OnModelCreatingPartial(modelBuilder);
            

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
