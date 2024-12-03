using MiniNetflix.Core.Dto;
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Helper.Pagination;

namespace MiniNetflix.Core.Interface.Services
{
    public interface ISerieService
    {
        Task<Serie> GetSerieWithGenre(int id);
        Task AddSerie(SerieDto serie);
        Task<bool> DeleteSerie(int id);
        PagedList<Serie> GetAllSerie(Filtered filtered);
        Task<Serie> GetSerie(int id);
        Task<bool> UpdateSerie(SerieDto serie);
    }
}