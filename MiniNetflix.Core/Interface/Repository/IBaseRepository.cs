using MiniNetflix.Core.Entities;

namespace MiniNetflix.Core.Interface.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        Task<bool> Delete(int id);
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<bool> Update(T entity);
    }
}