using BeerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Controllers
{
    public class BrandController : Controller
    {
        private readonly BeerAppContext _context; // '_' significa que la variable es privada

        public BrandController(BeerAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() // Metodos asincronos deben retornar Task
        {
            // _context => BD
            // Brands => Tabla
            // .ToListAsync() => devuelve una lista de objeyos del tipo Brands
            return View(await _context.Brands.ToListAsync());
        }
    }
}
