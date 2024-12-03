using System.ComponentModel.DataAnnotations;

namespace MiniNetflix.Presentation.ViewModelError
{
    public class ProductionViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
