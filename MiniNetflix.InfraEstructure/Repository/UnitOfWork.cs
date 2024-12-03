using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.InfraEstructure.Context;

namespace MiniNetflix.InfraEstructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MiniNetflixContext _context;
        private IGenreRepository? _genreRepository;
        private IProductionRepository _productionRepository;
        private ISerieRepository _serieRepository;
   

        public UnitOfWork(MiniNetflixContext context)
        {
            _context = context;
        }

        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_context);
        public IProductionRepository ProductionRepository => _productionRepository ??= new ProductionRepository(_context);
   
        public ISerieRepository SerieRepository => _serieRepository ??= new SerieRepository(_context);

        public void Dispose()
        {
            _context?.Dispose();
        }

        public void SaveChanges() => _context.SaveChanges();


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
