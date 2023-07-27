using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace one.Models;

public partial class RasmitestContext : DbContext
{
    public RasmitestContext()
    {
    }

    public RasmitestContext(DbContextOptions<RasmitestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Me> Mes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC0577\\MSSQL2019;Database=rasmitest;user id =sa;password=system;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Me>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mes__3213E83F46ED3143");

            entity.ToTable("mes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mes)
                .IsUnicode(false)
                .HasColumnName("mes");
            entity.Property(e => e.UserId).HasColumnName("userID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
