using MiniNetflix.Core.Dto;
using System.ComponentModel.DataAnnotations;

namespace MiniNetflix.Presentation.ViewModelError
{
    public class SerieDtoViewModel
    {
       
            public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Must have an ImageUrl")]
        [Url(ErrorMessage = "Invalid URL format for ImageUrl.")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Must have a YoutubeUrl")]
        [Url(ErrorMessage = "Invalid URL format for LinkVideo.")]
        public string? LinkVideo { get; set; }

        [Required(ErrorMessage = "ProductionId is required.")]
        public int? ProductionId { get; set; }

        public List<GenreDto>? GenresId { get; set; }
        
    }
}
