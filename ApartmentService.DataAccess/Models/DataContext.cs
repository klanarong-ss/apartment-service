using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApartmentService.DataAccess.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<SettingRoom> SettingRooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=188.166.210.217,1433;Initial Catalog=ApartmentService;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=Pass@Word#1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CI_AS");

        modelBuilder.Entity<Billing>(entity =>
        {
            entity.ToTable("Billing");

            entity.Property(e => e.BillingId).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RoomId).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SettingRoom>(entity =>
        {
            entity.HasKey(e => e.RoomId);

            entity.ToTable("SettingRoom");

            entity.Property(e => e.RoomId).HasMaxLength(40);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.RoomNumber).HasMaxLength(15);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
