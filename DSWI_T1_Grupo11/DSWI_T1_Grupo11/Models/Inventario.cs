using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_Grupo11.Models;

public partial class Inventario
{
    public int InventarioID { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public int? Cantidad { get; set; }
    [StringLength(100)]
    public string? Ubicacion { get; set; }
    [StringLength(50)]
    public string? Estado { get; set; }
    public int? ProductoID { get; set; }
    public Producto? Producto { get; set; }
}
