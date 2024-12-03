using MiniNetflix.Core.Entities;

namespace MiniNetflix.Core.Interface.Repository
{
    public interface IGenreSerieRepository
    {
        Task RemoveRange(IEnumerable<GenreSerie> genreSeries);
        List<GenreSerie> GetAllGenreSerieBySerieId(int id);
        Task<bool> DeleteRangeByGenreId(int id);
    }
}