using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.InfraEstructure.Context;
using System.Collections;



namespace MiniNetflix.InfraEstructure.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MiniNetflixContext context) : base(context) { }

        public  ICollection<Genre> GetAllGenresById(IEnumerable<int> ids)
        {
            List<Genre> result = new();
            foreach( var genre in GetAll())
            {
                if (ids.Contains(genre.Id))
                {
                    result.Add(genre);
                }
            }

            return result;
        }

    }
}
