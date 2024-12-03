
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface;

namespace MiniNetflix.InfraEstructure.Repository
{
    public interface IProductionRepository : IRepository<Production>
    {
        Task<bool> DeleteAsync(int id);
    }
}