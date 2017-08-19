namespace HippieTamTam.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogDatabaseContext : DbContext
    {
        public BlogDatabaseContext()
            : base("name=BlogDatabaseContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Layout> Layouts { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Post)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Layout>()
                .Property(e => e.LayoutName)
                .IsUnicode(false);

            modelBuilder.Entity<Layout>()
                .HasMany(e => e.Post)
                .WithRequired(e => e.Layout)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBackground)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBackgroundColor)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSubhead1)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSubhead2)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSubhead3)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSubhead4)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSubhead5)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText1)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText2)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText3)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText4)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText5)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText6)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText7)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText8)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText9)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostText10)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostQuote1)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostQuote2)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostQuote3)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostQuote4)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostQuote5)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostVideo1)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostVideo2)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostVideo3)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostVideo4)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImage1)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImage2)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImage3)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImage4)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImage5)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImageText1)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImageText2)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImageText3)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImageText4)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostBigImageText5)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSmallImage1)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSmallImage2)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSmallImage3)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSmallImage4)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostSmallImage5)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostAuthor)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostViewCount);
                

            modelBuilder.Entity<Post>()
                .Property(e => e.PostDateCreated);
                

            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminUsername)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminPassword)
                .IsUnicode(false);
        }
    }
}
