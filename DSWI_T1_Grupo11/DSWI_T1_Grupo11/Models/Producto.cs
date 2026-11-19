using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_Grupo11.Models;

public partial class Producto
{
    public int ProductoID { get; set; }
    [StringLength(100)]
    public string? Nombre { get; set; }
    [StringLength(50)]
    public string? Categoria { get; set; }
    public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
