using DSWI_T1_Grupo11.Models;
using DSWI_T1_Grupo11.Repositories;

namespace DSWI_T1_Grupo11.Services;

public class InventarioService(IInventarioRepository repository, IProductoRepository productos) : IInventarioService
{
    public async Task<List<Inventario>> ListarAsync()
    {
        var filas = await repository.ListarAsync();
        var catalogo = (await productos.ListarAsync()).ToDictionary(p => p.ProductoID);
        foreach (var fila in filas)
        {
            if (fila.ProductoID is int id)
                fila.Producto = catalogo.GetValueOrDefault(id);
        }
        return filas;
    }

    public async Task<Inventario?> ObtenerPorIdAsync(int id)
    {
        var fila = await repository.ObtenerPorIdAsync(id);
        if (fila?.ProductoID is int productoId)
            fila.Producto = await productos.ObtenerPorIdAsync(productoId);
        return fila;
    }

    public Task<Inventario> CrearAsync(Inventario registro) =>
        repository.CrearAsync(registro);

    public Task<Inventario?> EditarAsync(Inventario registro) =>
        repository.EditarAsync(registro);
}
