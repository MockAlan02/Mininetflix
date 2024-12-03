using MiniNetflix.Core.Entities;

namespace MiniNetflix.Core.Dto
{
    public class SerieDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? LinkVideo { get; set; }
        public int? ProductionId { get; set; }
        public List<GenreDto>? GenresId { get; set; }
    }

    public class GenreDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
        public class SerieWithGenresDto
        
    {
        public Serie? Serie { get; set; }
        public List<GenreSerie>? Genres { get; set; }
    }
}
