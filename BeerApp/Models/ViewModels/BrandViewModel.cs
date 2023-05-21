using System.ComponentModel.DataAnnotations;

namespace BeerApp.Models.ViewModels
{
	public class BrandViewModel
	{
		[Required]
		[Display(Name = "Marca")]
		public string Name { get; set; }
    }
}
