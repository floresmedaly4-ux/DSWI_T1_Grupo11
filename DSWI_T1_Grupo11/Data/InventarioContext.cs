using DSWI_T1_Grupo11.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_Grupo11.Data;

public partial class InventarioContext(DbContextOptions<InventarioContext> options) : DbContext(options)
{
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Inventario> Inventarios => Set<Inventario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Productos", "dbo");
            entity.HasKey(p => p.ProductoID);
            entity.Property(p => p.Nombre).HasMaxLength(100);
            entity.Property(p => p.Categoria).HasMaxLength(50);
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.ToTable("Inventario", "dbo");
            entity.HasKey(i => i.InventarioID);
            entity.Property(i => i.FechaIngreso).HasColumnType("date");
            entity.Property(i => i.Ubicacion).HasMaxLength(100);
            entity.Property(i => i.Estado).HasMaxLength(50);
            entity.HasOne(i => i.Producto)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(i => i.ProductoID);
        });
    }
}
