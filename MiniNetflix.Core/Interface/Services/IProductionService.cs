using MiniNetflix.Core.Entities;

namespace MiniNetflix.Core.Interface.Services
{
    public interface IProductionService
    {
        Task AddProduction(Production production);
        Task<bool> DeleteProduction(int id);
        IEnumerable<Production> GetAllProduction();
        Task<Production> GetProduction(int id);
        Task<bool> UpdateProduction(Production production);
    }
}