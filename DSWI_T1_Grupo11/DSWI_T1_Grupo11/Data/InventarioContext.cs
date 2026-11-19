using System;
using System.Collections.Generic;
using DSWI_T1_Grupo11.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_Grupo11.Data;

public partial class InventarioContext : DbContext
{
    public InventarioContext(DbContextOptions<InventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.InventarioID).HasName("PK__Inventar__FB8A24B73A749ABC");

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios).HasConstraintName("FK__Inventari__Produ__398D8EEE");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoID).HasName("PK__Producto__A430AE8323378A92");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
