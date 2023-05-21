using System.ComponentModel.DataAnnotations;

namespace BeerApp.Models.ViewModels
{
	public class BeerViewModel
	{
		[Required]
        [Display(Name = "Nombre")] // Mostrar 'Nombre' en lugar de 'Name'
        public string Name { get; set; }

		[Required]
		[Display(Name = "Marca")]
		public int BrandId { get; set; }
    }
}
