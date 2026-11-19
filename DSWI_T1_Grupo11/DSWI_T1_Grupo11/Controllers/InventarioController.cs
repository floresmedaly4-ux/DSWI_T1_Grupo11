using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DSWI_T1_Grupo11.Models;
using DSWI_T1_Grupo11.Services;

namespace DSWI_T1_Grupo11.Controllers;

public class InventarioController(IInventarioService servicio, IProductoService productos) : Controller
{
    public async Task<IActionResult> Index() => View(await servicio.ListarAsync());

    private async Task CargarProductosAsync(int? seleccionado)
    {
        ViewBag.ProductoID = new SelectList(await productos.ListarAsync(), "ProductoID", "Nombre", seleccionado);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await CargarProductosAsync(null);
        return View(new Inventario());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FechaIngreso,Cantidad,Ubicacion,Estado,ProductoID")] Inventario registro)
    {
        if (registro.ProductoID is int productoId && await productos.ObtenerPorIdAsync(productoId) is null)
            ModelState.AddModelError(nameof(registro.ProductoID), "Selecciona un producto existente.");
        if (!ModelState.IsValid)
        {
            await CargarProductosAsync(registro.ProductoID);
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
        await CargarProductosAsync(registro.ProductoID);
        return View(registro);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("InventarioID,FechaIngreso,Cantidad,Ubicacion,Estado,ProductoID")] Inventario registro)
    {
        if (id != registro.InventarioID) return BadRequest();
        if (registro.ProductoID is int productoId && await productos.ObtenerPorIdAsync(productoId) is null)
            ModelState.AddModelError(nameof(registro.ProductoID), "Selecciona un producto existente.");
        if (!ModelState.IsValid)
        {
            await CargarProductosAsync(registro.ProductoID);
            return View(registro);
        }

        if (await servicio.EditarAsync(registro) is null) return NotFound();
        return RedirectToAction(nameof(Index));
    }
}
