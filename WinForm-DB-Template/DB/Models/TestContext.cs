using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinForm_DB_Template.DB.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ISale> ISales { get; set; }

    public virtual DbSet<ISalesDetail> ISalesDetails { get; set; }

    public virtual DbSet<MItem> MItems { get; set; }

    public virtual DbSet<MStore> MStores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=test;Port=5432;Username=postgres;Password=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ISale>(entity =>
        {
            entity.HasKey(e => e.SalesId).HasName("I_Sales_pkey");

            entity.ToTable("I_Sales");

            entity.Property(e => e.SalesId)
                .ValueGeneratedNever()
                .HasColumnName("SalesID");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");
        });

        modelBuilder.Entity<ISalesDetail>(entity =>
        {
            entity.HasKey(e => new { e.SalesId, e.DetailSeqNo }).HasName("I_SalesDetail_pkey");

            entity.ToTable("I_SalesDetail");

            entity.Property(e => e.SalesId).HasColumnName("SalesID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
        });

        modelBuilder.Entity<MItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("M_Item_pkey");

            entity.ToTable("M_Item");

            entity.Property(e => e.ItemId)
                .ValueGeneratedNever()
                .HasColumnName("ItemID");
        });

        modelBuilder.Entity<MStore>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("M_Store_pkey");

            entity.ToTable("M_Store");

            entity.Property(e => e.StoreId)
                .ValueGeneratedNever()
                .HasColumnName("StoreID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
