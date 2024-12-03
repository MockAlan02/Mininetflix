

using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.Core.Interface.Services;

namespace MiniNetflix.Core.Service
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenreSerieRepository _genreSerieRepository;

        public GenreService(IUnitOfWork unitOfWork, IGenreSerieRepository genreSerieRepository)
        {
            _unitOfWork = unitOfWork;
            _genreSerieRepository = genreSerieRepository;
        }
        public IEnumerable<Genre> GetAllGenre()
        {
            return _unitOfWork.GenreRepository.GetAll();
        }

        public async Task<Genre> GetGenre(int id)
        {
            return await _unitOfWork.GenreRepository.GetById(id);
        }

        public async Task AddGenre(Genre genre)
        {
            await _unitOfWork.GenreRepository.Add(genre);
            _unitOfWork.SaveChanges();
        }


        public async Task<bool> UpdateGenre(Genre genre)
        {
            var response = await _unitOfWork.GenreRepository.Update(genre);
            await _unitOfWork.SaveChangesAsync();
            return response;
        }

        public async Task<bool> DeleteGenre(int id)
        {
            await _genreSerieRepository.DeleteRangeByGenreId(id);
            var response = await _unitOfWork.GenreRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return response;
        }
    }
}
