using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Entities;
using MiniNetflix.InfraEstructure.Context;


namespace MiniNetflix.InfraEstructure.Repository
{
    public class ProductionRepository : BaseRepository<Production>, IProductionRepository
    {
        public ProductionRepository(MiniNetflixContext context) : base(context)
        {
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var production = await _context.Production.FirstOrDefaultAsync( p => p.Id == id);
            if (production == null)
            {
                return false;
            }

            _context.Production.Remove(production);
            await _context.SaveChangesAsync();
            return true;

        }

    }
}
