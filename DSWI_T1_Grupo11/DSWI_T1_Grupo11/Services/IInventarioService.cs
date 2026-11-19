using DSWI_T1_Grupo11.Models;

namespace DSWI_T1_Grupo11.Services;

public interface IInventarioService
{
    Task<List<Inventario>> ListarAsync();
    Task<Inventario?> ObtenerPorIdAsync(int id);
    Task<Inventario> CrearAsync(Inventario registro);
    Task<Inventario?> EditarAsync(Inventario registro);
}
