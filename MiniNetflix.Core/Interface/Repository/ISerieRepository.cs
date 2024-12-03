using MiniNetflix.Core.Dto;
using MiniNetflix.Core.Entities;

namespace MiniNetflix.Core.Interface
 {
     public interface ISerieRepository : IRepository<Serie>
     {
        Task<Serie> GetSerieIdWithGenre(int id);
        IQueryable<Serie> Queryable();
        Task DeleteSerieByProductionId(int id);
        Task<bool> DeleteSeries(IEnumerable<Serie> serieList);
        IEnumerable<Serie> GetSeriesByProductionId(int id);


    }
}