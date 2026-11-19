using Microsoft.AspNetCore.Mvc;
using DSWI_T1_Grupo11.Models;
using DSWI_T1_Grupo11.Services;

namespace DSWI_T1_Grupo11.Controllers;

public class ProductosController(IProductoService servicio) : Controller
{
    public async Task<IActionResult> Index() => View(await servicio.ListarAsync());

    [HttpGet]
    public IActionResult Create() => View(new Producto());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nombre,Categoria")] Producto registro)
    {
        if (!ModelState.IsValid)
        {
            return View(registro);
        }

        await servicio.CrearAsync(registro);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var registro = await servicio.ObtenerPorIdAsync(id);
        if (registro is null) return NotFound();
        return View(registro);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ProductoID,Nombre,Categoria")] Producto registro)
    {
        if (id != registro.ProductoID) return BadRequest();
        if (!ModelState.IsValid)
        {
            return View(registro);
        }

        if (await servicio.EditarAsync(registro) is null) return NotFound();
        return RedirectToAction(nameof(Index));
    }
}
