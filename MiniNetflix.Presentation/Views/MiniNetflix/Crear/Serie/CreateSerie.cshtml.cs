
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniNetflix.Presentation.ViewModelError;

namespace MiniNetflix.Presentation.Views.MiniNetflix.Crear.Serie
{
    public class CreateSerieModel : PageModel
    {
       
        public SerieDtoViewModel? SerieDtoViewModel {get; set;} 
        public void OnGet()
        {
        }
        
        public void OnPost()
        {

        }
    }
}
