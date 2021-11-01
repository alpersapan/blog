using Microsoft.EntityFrameworkCore;
using blog.Models;

#nullable disable

namespace blog.Data
{
    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {
        }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogCategoryUser> BlogCategoryUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.BlogId).HasColumnName("blogID");

                entity.Property(e => e.BlogContent).HasColumnName("blogContent");

                entity.Property(e => e.BlogDate)
                    .HasColumnType("date")
                    .HasColumnName("blogDate");

                entity.Property(e => e.BlogTitle)
                    .HasMaxLength(150)
                    .HasColumnName("blogTitle");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<BlogCategoryUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BlogCategoryUser");

                entity.Property(e => e.BlogContent).HasColumnName("blogContent");

                entity.Property(e => e.BlogDate)
                    .HasColumnType("date")
                    .HasColumnName("blogDate");

                entity.Property(e => e.BlogId).HasColumnName("blogID");

                entity.Property(e => e.BlogTitle)
                    .HasMaxLength(150)
                    .HasColumnName("blogTitle");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("categoryName");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserMail)
                    .HasMaxLength(50)
                    .HasColumnName("userMail");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPw)
                    .HasMaxLength(50)
                    .HasColumnName("userPw");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserMail)
                    .HasMaxLength(50)
                    .HasColumnName("userMail");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPw)
                    .HasMaxLength(50)
                    .HasColumnName("userPw");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
