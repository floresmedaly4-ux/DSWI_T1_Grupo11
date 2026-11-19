using DSWI_T1_Grupo11.Models;
using DSWI_T1_Grupo11.Data;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_Grupo11.Repositories;

public class ProductoRepository(InventarioContext contexto) : IProductoRepository
{
    public async Task<List<Producto>> ListarAsync()
    {
        return await contexto.Productos
            .FromSql($"EXEC dbo.usp_Producto_Listar")
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Producto?> ObtenerPorIdAsync(int id)
    {
        var filas = await contexto.Productos
            .FromSql($"EXEC dbo.usp_Producto_ObtenerPorId {id}")
            .AsNoTracking()
            .ToListAsync();
        return filas.SingleOrDefault();
    }

    public async Task<Producto> CrearAsync(Producto registro)
    {
        var filas = await contexto.Productos
            .FromSql($"EXEC dbo.usp_Producto_Crear {registro.Nombre}, {registro.Categoria}")
            .AsNoTracking()
            .ToListAsync();
        return filas.Single();
    }

    public async Task<Producto?> EditarAsync(Producto registro)
    {
        var filas = await contexto.Productos
            .FromSql($"EXEC dbo.usp_Producto_Editar {registro.ProductoID}, {registro.Nombre}, {registro.Categoria}")
            .AsNoTracking()
            .ToListAsync();
        return filas.SingleOrDefault();
    }
}
