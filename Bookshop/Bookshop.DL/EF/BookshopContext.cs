using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Bookshop.DL.Entities;
using Bookshop.DL.Helpers;
using System.Collections.Generic;
using System.IO;

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
            bool newlyCreated = Database.EnsureCreated();
            if (newlyCreated)
            {
                try
                {
                    SeedData.SeedAuthorsAndTheirBooks(this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR. Failed to seed data for authors and their books.");
                    string error = @$"Error Message: {ex.Message}\n
                                    StackTrace: {ex.StackTrace}\n
                                    InnerException.Message: {ex.InnerException.Message}\n";
                    Console.WriteLine(error);
                    File.WriteAllText(@"D:\Documents\Nazar\University\Master's paper\FullProject\Bookshop", error);
                }
            }
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorsBooks> AuthorsBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BooksGenres> BooksGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=bookshopdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //modelBuilder.Entity<Author>(entity =>
            //{
            //    entity.ToTable("Author");

            //    entity.Property(e => e.Id).UseIdentityColumn();

            //    entity.Property(e => e.About)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Surname)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<AuthorsBooks>(entity =>
            //{
            //    entity.HasKey(e => new { e.AuthorID, e.BookID });

            //    entity.HasOne(d => d.Author)
            //        .WithMany(p => p.AuthorsBooks)
            //        .HasForeignKey(d => d.AuthorID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AuthorsBooks.AuthorID");

            //    entity.HasOne(d => d.Book)
            //        .WithMany(p => p.AuthorsBooks)
            //        .HasForeignKey(d => d.BookID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AuthorsBooks.BookID");
            //});

            //modelBuilder.Entity<Book>(entity =>
            //{
            //    entity.ToTable("Book");

            //    entity.Property(e => e.ID).UseIdentityColumn();

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Price).HasColumnType("numeric(19, 0)");

            //    entity.Property(e => e.PublisherName)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Title)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Weight).HasColumnType("numeric(19, 0)");
            //});

            //modelBuilder.Entity<BooksGenres>(entity =>
            //{
            //    entity.HasKey(e => new { e.BookID, e.GenreID });

            //    entity.HasOne(d => d.Book)
            //        .WithMany(p => p.BooksGenres)
            //        .HasForeignKey(d => d.BookID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_BooksGenres.BookID");

            //    entity.HasOne(d => d.Genre)
            //        .WithMany(p => p.BooksGenres)
            //        .HasForeignKey(d => d.GenreID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_BooksGenres.GenreID");
            //});

            //modelBuilder.Entity<Genre>(entity =>
            //{
            //    entity.ToTable("Genre");

            //    entity.Property(e => e.ID).UseIdentityColumn();

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Order>(entity =>
            //{
            //    entity.ToTable("Order");

            //    entity.Property(e => e.ID).UseIdentityColumn();

            //    entity.Property(e => e.DateCreated).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<OrderItem>(entity =>
            //{
            //    entity.ToTable("OrderItem");

            //    entity.Property(e => e.ID).UseIdentityColumn();

            //    entity.HasOne(d => d.Book)
            //        .WithMany(p => p.OrderItems)
            //        .HasForeignKey(d => d.BookId)
            //        .HasConstraintName("FK_OrderItem.BookID");

            //    entity.HasOne(d => d.Order)
            //        .WithMany(p => p.Items)
            //        .HasForeignKey(d => d.OrderId)
            //        .HasConstraintName("FK_OrderItem.OrderID");
            //});

            //modelBuilder.Entity<Client>(entity =>
            //{
            //    entity.ToTable("Client");

            //    entity.Property(e => e.ID).UseIdentityColumn();

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Surname)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Email)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Number)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Password)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<ClientsOrders>(entity =>
            //{
            //    entity.HasKey(e => new { e.ClientID, e.OrderID });

            //    entity.HasOne(d => d.Client)
            //        .WithMany(p => p.ClientsOrders)
            //        .HasForeignKey(d => d.ClientID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_ClientsOrders.ClientID");

            //    entity.HasOne(d => d.Order)
            //        .WithMany(p => p.ClientsOrders)
            //        .HasForeignKey(d => d.OrderID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_ClientsOrders.OrderID");
            //});
        }
    }
}
