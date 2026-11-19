using DSWI_T1_Grupo11.Models;
using DSWI_T1_Grupo11.Data;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_Grupo11.Repositories;

public class InventarioRepository(InventarioContext contexto) : IInventarioRepository
{
    public async Task<List<Inventario>> ListarAsync()
    {
        return await contexto.Inventarios
            .FromSql($"EXEC dbo.usp_Inventario_Listar")
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Inventario?> ObtenerPorIdAsync(int id)
    {
        var filas = await contexto.Inventarios
            .FromSql($"EXEC dbo.usp_Inventario_ObtenerPorId {id}")
            .AsNoTracking()
            .ToListAsync();
        return filas.SingleOrDefault();
    }

    public async Task<Inventario> CrearAsync(Inventario registro)
    {
        var filas = await contexto.Inventarios
            .FromSql($"EXEC dbo.usp_Inventario_Crear {registro.FechaIngreso}, {registro.Cantidad}, {registro.Ubicacion}, {registro.Estado}, {registro.ProductoID}")
            .AsNoTracking()
            .ToListAsync();
        return filas.Single();
    }

    public async Task<Inventario?> EditarAsync(Inventario registro)
    {
        var filas = await contexto.Inventarios
            .FromSql($"EXEC dbo.usp_Inventario_Editar {registro.InventarioID}, {registro.FechaIngreso}, {registro.Cantidad}, {registro.Ubicacion}, {registro.Estado}, {registro.ProductoID}")
            .AsNoTracking()
            .ToListAsync();
        return filas.SingleOrDefault();
    }
}
