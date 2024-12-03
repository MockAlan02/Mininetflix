using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModelError
{
    public class PersonaViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        public string? Option { get; set; } = "";
    }
}
