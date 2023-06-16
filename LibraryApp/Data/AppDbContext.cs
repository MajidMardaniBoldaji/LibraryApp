using System;
using System.Collections.Generic;
using LibraryApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookBorrow> BookBorrows { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.AddDate)
                .HasPrecision(2)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.UpdateDate).HasPrecision(2);
        });

        modelBuilder.Entity<BookBorrow>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BookBorrow");

            entity.Property(e => e.BorrowDate).HasPrecision(2);
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.ReturnDate).HasPrecision(2);
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.ToTable("BookCategory");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.AddDate)
                .HasPrecision(2)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.BirthDate).HasPrecision(0);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UpdateDate).HasPrecision(2);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
