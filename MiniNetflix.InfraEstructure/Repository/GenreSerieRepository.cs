using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.InfraEstructure.Context;
using System.Threading.Tasks;


namespace MiniNetflix.InfraEstructure.Repository
{
    public class GenreSerieRepository : IGenreSerieRepository
    {

        private readonly MiniNetflixContext _context;
        public GenreSerieRepository(MiniNetflixContext context)
        {
            _context = context;
        }

        public async Task<GenreSerie> GetByGenreId(int id)
        {
            return await _context.GenreSeries.FirstOrDefaultAsync(t => t.SerieId == id);
        }
        public async  Task RemoveRange(IEnumerable<GenreSerie> genreSeries)
        {
            _context.GenreSeries.RemoveRange(genreSeries);
             await _context.SaveChangesAsync();
        }
        public List<GenreSerie> GetAllGenreSerieBySerieId(int id)
        {
            return _context.GenreSeries.Where(t => t.SerieId == id).Include(t => t.Genre).ToList();
        }
        public async Task<bool> DeleteRangeByGenreId(int id)
        {
            var GenreSerie = _context.GenreSeries.Where(t => t.Genre!.Id == id);
            await RemoveRange(GenreSerie);
            return true;
        }
        
    }
}
