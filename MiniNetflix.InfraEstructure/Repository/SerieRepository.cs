using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface;
using MiniNetflix.InfraEstructure.Context;
using MiniNetflix.InfraEstructure.Repository;

public class SerieRepository : BaseRepository<Serie>,IRepository<Serie>, ISerieRepository
{
    public SerieRepository(MiniNetflixContext context) : base(context){}

    public async Task<Serie> GetSerieIdWithGenre(int id)
    {
        var serie = await _entities
                        .Include(s => s.GenreSeries)
                            .ThenInclude(gs => gs.Genre) // Incluimos los géneros asociados
                        .FirstOrDefaultAsync(s => s.Id == id);

        if (serie == null)
            return null;

        return serie;
    }
    
    public IQueryable<Serie> Queryable()
    {
        return _context.Set<Serie>().Include(t => t.GenreSeries);
    }

    public async Task DeleteSerieByProductionId(int id)
    {
        var list = await _entities.Where(t => t.ProductionId == id).ToListAsync();
        _context.Serie.RemoveRange(list);
         await _context.SaveChangesAsync();
    }
    public IEnumerable<Serie> GetSeriesByProductionId(int id)
    {
        return _context.Serie.Where(t => t.ProductionId == id).Include(t => t.GenreSeries).ToList();
    }

    public  Task<bool> DeleteSeries(IEnumerable<Serie> serieList)
    {
         _context.Serie.RemoveRange(serieList);
        return Task.FromResult(true);
    }
}



