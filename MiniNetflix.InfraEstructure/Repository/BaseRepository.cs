using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.InfraEstructure.Context;


namespace MiniNetflix.InfraEstructure.Repository
{
    public class BaseRepository<T> : IRepository<T>, IBaseRepository<T> where T : BaseEntity
    {
        private protected MiniNetflixContext _context;

        private protected DbSet<T> _entities;
        public BaseRepository(MiniNetflixContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FirstAsync(x => x.Id == id);
        }

        public Task<bool> Update(T entity)
        {
            _entities.Update(entity);
            return Task.FromResult(true);
        }

        public IQueryable<T> GetQueryable()
        {
            return _entities.AsQueryable();
        }
    }
}
