using DSWI_T1_Grupo11.Models;

namespace DSWI_T1_Grupo11.Repositories;

public interface IProductoRepository
{
    Task<List<Producto>> ListarAsync();
    Task<Producto?> ObtenerPorIdAsync(int id);
    Task<Producto> CrearAsync(Producto registro);
    Task<Producto?> EditarAsync(Producto registro);
}
