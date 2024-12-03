using MiniNetflix.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniNetflix.Core.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll();

        public Task<T> GetById(int id);
        public Task Add(T entity);
        Task<bool> Delete(int id);
        public Task<bool> Update(T entity);

        IQueryable<T> GetQueryable();

    }
}
