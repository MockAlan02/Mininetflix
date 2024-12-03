using MiniNetflix.Core.Entities;
using System.Collections;

namespace MiniNetflix.Core.Interface.Repository
{
    public interface IGenreRepository : IRepository<Genre>
    {
        ICollection<Genre> GetAllGenresById(IEnumerable<int> ids);
    }
}