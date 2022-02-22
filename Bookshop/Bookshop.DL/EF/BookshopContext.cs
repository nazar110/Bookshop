using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Bookshop.DL.Entities;

#nullable disable

namespace Bookshop.DL.EF
{
    public partial class BookshopContext : DbContext
    {
        public BookshopContext()
        {
        }

        public BookshopContext(DbContextOptions<BookshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorsBook> AuthorsBooks { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BooksGenre> BooksGenres { get; set; }
        public virtual DbSet<ClientInformation> ClientInformations { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GuestClient> GuestClients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<SignedUpClient> SignedUpClients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=bookshopdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.About)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuthorsBook>(entity =>
            {
                entity.HasKey(e => new { e.AuthorID, e.BookID })
                    .HasName("PK__AuthorsB__1304F036FBF6F34A");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.AuthorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorsBooks.AuthorID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.BookID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorsBooks.BookID");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PublisherName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnType("numeric(19, 0)");
            });

            modelBuilder.Entity<BooksGenre>(entity =>
            {
                entity.HasKey(e => new { e.BookID, e.GenreID })
                    .HasName("PK__BooksGen__CDD89272C3DCC380");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BooksGenres)
                    .HasForeignKey(d => d.BookID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksGenres.BookID");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BooksGenres)
                    .HasForeignKey(d => d.GenreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksGenres.GenreID");
            });

            modelBuilder.Entity<ClientInformation>(entity =>
            {
                entity.ToTable("ClientInformation");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GuestClient>(entity =>
            {
                entity.ToTable("GuestClient");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.ClientInformation)
                    .WithMany(p => p.GuestClients)
                    .HasForeignKey(d => d.ClientInformationID)
                    .HasConstraintName("FK_GuestClient.ClientInformationID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.ClientInformation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientInformationID)
                    .HasConstraintName("FK_Order.ClientInformationID");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.BookID)
                    .HasConstraintName("FK_OrderItem.BookID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderID)
                    .HasConstraintName("FK_OrderItem.OrderID");
            });

            modelBuilder.Entity<SignedUpClient>(entity =>
            {
                entity.ToTable("SignedUpClient");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientInformation)
                    .WithMany(p => p.SignedUpClients)
                    .HasForeignKey(d => d.ClientInformationID)
                    .HasConstraintName("FK_SignedUpClient.ClientInformationID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
