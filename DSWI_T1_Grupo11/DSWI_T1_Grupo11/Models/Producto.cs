using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_Grupo11.Models;

public partial class Producto
{
    [Key]
    public int ProductoID { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    public string? Categoria { get; set; }

    [InverseProperty("Producto")]
    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
