
namespace DSWI_T1_Grupo11.Models
{
    public class Inventario
    {
        public int InventarioID { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int Cantidad { get; set; }

        public string Ubicacion { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public int ProductoID { get; set; }

        public Producto? Producto { get; set; }
    }
}
