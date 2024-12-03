using MiniNetflix.Core.Entities;

namespace MiniNetflix.Core.Interface.Services
{
    public interface IGenreService
    {
        Task AddGenre(Genre genre);
        Task<bool> DeleteGenre(int id);
        IEnumerable<Genre> GetAllGenre();
        Task<Genre> GetGenre(int id);
        Task<bool> UpdateGenre(Genre genre);
    }
}