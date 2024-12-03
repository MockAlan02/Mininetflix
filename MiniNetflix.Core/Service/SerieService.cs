using MiniNetflix.Core.Dto;
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Helper.Pagination;
using MiniNetflix.Core.Interface;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.Core.Interface.Services;


namespace MiniNetflix.Core.Service
{
    public class SerieService : ISerieService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenreSerieRepository _genreSerieRepository;

        public SerieService(IUnitOfWork unitOfWork, IGenreSerieRepository genreSerieRepository)
        {
            _unitOfWork = unitOfWork;
            _genreSerieRepository = genreSerieRepository;
        }

        public PagedList<Serie> GetAllSerie(Filtered? filtered = null)
        {

             IQueryable<Serie> serieQuery = _unitOfWork.SerieRepository.Queryable();

              if (filtered == null)
              {
                  return PagedList<Serie>.Create(serieQuery, 1, 10);
              }


              if (!string.IsNullOrEmpty(filtered?.Name))
              {
                  serieQuery = serieQuery.Where(p => p.Name.ToLower().StartsWith(filtered.Name.ToLower()));
              }

              if (filtered?.Production > 0)
              {
                  serieQuery = serieQuery.Where(p => p.ProductionId == filtered.Production);
              }

              if (filtered?.Genre != null)
              {
                  if (filtered.Genre!.Length > 1)
                  {

                      serieQuery = serieQuery.Where(t => t.GenreSeries!.All(t => filtered.Genre!.Contains(t.GenreId)));

                  } 
                  else
                  {
                      serieQuery = serieQuery.Where(t => t.GenreSeries!.Any(t => filtered.Genre!.Contains(t.GenreId)));

                  }
              }


              return PagedList<Serie>.Create(serieQuery, filtered!.Page, filtered.PageSize);
          
        }

        public async Task<Serie> GetSerie(int id)
        {
            return await _unitOfWork.SerieRepository.GetById(id);
        }

        public  async Task<Serie> GetSerieWithGenre(int id)
        {
            var serie = await _unitOfWork.SerieRepository.GetSerieIdWithGenre(id);
            return serie; 
        }

        public async Task AddSerie(SerieDto serieDto)
        {
            var serie = new Serie
            {
                Name = serieDto.Name!,
                ImageUrl = serieDto.ImageUrl!,
                LinkVideo = serieDto.LinkVideo!,
                ProductionId = (int)serieDto.ProductionId!,
            };

            var genres = _unitOfWork.GenreRepository
                            .GetAllGenresById(serieDto.GenresId.Select(t => t.Id).ToList());

            // Asignar géneros a la serie
            serie.GenreSeries = genres.Select(genre => new GenreSerie
            {
                GenreId = genre.Id,
                Genre = genre,
                SerieId = serie.Id,
                Serie = serie
            }).ToList();
            await _unitOfWork.SerieRepository.Add(serie);
            _unitOfWork.SaveChanges();
        }


        public async Task<bool> UpdateSerie(SerieDto serieDto)
        {
            var serie = await GetSerieWithGenre(serieDto.Id);
           await _genreSerieRepository.RemoveRange(serie.GenreSeries);

            serie = await GetSerieWithGenre(serieDto.Id);
            serie.Name = serieDto.Name!;
            serie.LinkVideo = serieDto.LinkVideo!;  
            serie.ImageUrl = serieDto.ImageUrl!;
            serie.ProductionId = (int)serieDto.ProductionId!;
            serie.GenreSeries.Clear();
            var genres = _unitOfWork.GenreRepository.GetAllGenresById(serieDto.GenresId!.Select(t => t.Id).ToList());

            foreach (var genre in genres)
            {
                serie.GenreSeries.Add(new GenreSerie
                {
                    SerieId = serieDto.Id,
                    GenreId = genre.Id,
                });
            }

               await _unitOfWork.SerieRepository.Update(serie);
               await _unitOfWork.SaveChangesAsync();
               return true;
         
        }

        public async Task<bool> DeleteSerie(int id)
        {
            var data = await _unitOfWork.SerieRepository.GetSerieIdWithGenre(id);
            _genreSerieRepository.RemoveRange(data.GenreSeries);
            var response = await _unitOfWork.SerieRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return  response;
        }


    }
}
