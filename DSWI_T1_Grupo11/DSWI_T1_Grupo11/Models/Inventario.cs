using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_Grupo11.Models;

[Table("Inventario")]
public partial class Inventario
{
    [Key]
    public int InventarioID { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public int? Cantidad { get; set; }

    [StringLength(100)]
    public string? Ubicacion { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

    public int? ProductoID { get; set; }

    [ForeignKey("ProductoID")]
    [InverseProperty("Inventarios")]
    public virtual Producto? Producto { get; set; }
}
