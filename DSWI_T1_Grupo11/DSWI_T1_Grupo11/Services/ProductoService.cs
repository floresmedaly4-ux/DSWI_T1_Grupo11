using DSWI_T1_Grupo11.Models;
using DSWI_T1_Grupo11.Repositories;

namespace DSWI_T1_Grupo11.Services;

public class ProductoService(IProductoRepository repository) : IProductoService
{
    public Task<List<Producto>> ListarAsync() =>
        repository.ListarAsync();

    public Task<Producto?> ObtenerPorIdAsync(int id) =>
        repository.ObtenerPorIdAsync(id);

    public Task<Producto> CrearAsync(Producto registro) =>
        repository.CrearAsync(registro);

    public Task<Producto?> EditarAsync(Producto registro) =>
        repository.EditarAsync(registro);
}
