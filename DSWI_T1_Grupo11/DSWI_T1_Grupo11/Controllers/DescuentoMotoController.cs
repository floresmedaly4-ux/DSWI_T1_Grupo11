
using Microsoft.AspNetCore.Mvc;
using DSWI_T1_Grupo11.Models;

namespace DSWI_T1_Grupo11.Controllers
{
    public class DescuentoMotoController : Controller
    {
        public IActionResult Index()
        {
            DescuentoMoto moto = new DescuentoMoto();

            return View(moto);
        }
    }
}
