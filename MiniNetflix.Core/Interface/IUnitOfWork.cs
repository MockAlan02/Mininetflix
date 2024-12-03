using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.InfraEstructure.Repository;

namespace MiniNetflix.Core.Interface
{
    public interface IUnitOfWork
    {
        IGenreRepository GenreRepository { get; }
        public IProductionRepository ProductionRepository { get; }
       ISerieRepository SerieRepository { get; }
        Task SaveChangesAsync();
        void SaveChanges();
    }
}