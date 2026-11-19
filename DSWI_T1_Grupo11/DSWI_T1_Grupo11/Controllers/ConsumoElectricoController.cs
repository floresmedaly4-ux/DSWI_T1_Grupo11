
using Microsoft.AspNetCore.Mvc;
using DSWI_T1_Grupo11.Models;

namespace DSWI_T1_Grupo11.Controllers
{
    public class ConsumoElectricoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ConsumoElectrico());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ConsumoElectrico modelo)
        {
            if (modelo.KwhConsumidos < 0)
            {
                ModelState.AddModelError(
                    "KwhConsumidos",
                    "El consumo no puede ser negativo."
                );
            }

            return View(modelo);
        }
    }
}
