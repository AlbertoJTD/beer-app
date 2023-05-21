using BeerApp.Models;
using BeerApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		public IActionResult Create()
		{
			return View();
		}

        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BrandViewModel model)
		{
			if (ModelState.IsValid)
			{
				var brand = new Brand()
				{
					Name = model.Name
				};
				_context.Add(brand);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index)); // Retornar al metodo index
			}

			return View(model);
		}
	}
}
