
namespace MiniNetflix.Core.Entities
{
    public class GenreSerie
    {
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int SerieId { get; set; }
        public Serie? Serie { get; set; }
    }
}
