
using Microsoft.EntityFrameworkCore;
using DSWI_T1_Grupo11.Models;

namespace DSWI_T1_Grupo11.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
    }
}
