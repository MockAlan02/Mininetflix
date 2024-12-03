using System.ComponentModel.DataAnnotations;

namespace MiniNetflix.Presentation.ViewModelError
{
    public class GenreViewModel
    {
        [Required(ErrorMessage ="Name of the Genre is Required")]
        public string Name { get; set; }
    }
}
