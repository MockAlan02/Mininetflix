

using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.Core.Interface.Services;
using MiniNetflix.InfraEstructure.Repository;

namespace MiniNetflix.Core.Service
{
    public class ProductionService : IProductionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISerieService _serieService;
        private readonly IProductionRepository _productionRepository;
        private readonly IGenreSerieRepository _genreSerieRepository;

        public ProductionService(IUnitOfWork unitOfWork, ISerieService serieService, IProductionRepository productionRepository, IGenreSerieRepository genreSerieRepository)
        {
            _unitOfWork = unitOfWork;
            _serieService = serieService;
            _productionRepository = productionRepository;
            _genreSerieRepository = genreSerieRepository;
        }
        public IEnumerable<Production> GetAllProduction()
        {
            return _unitOfWork.ProductionRepository.GetAll();
        }

        public async Task<Production> GetProduction(int id)
        {
            return await _unitOfWork.ProductionRepository.GetById(id);
        }

        public async Task AddProduction(Production production)
        {
            await _unitOfWork.ProductionRepository.Add(production);
            _unitOfWork.SaveChanges();
        }


        public async Task<bool> UpdateProduction(Production production)
        {
            var response = await _unitOfWork.ProductionRepository.Update(production);
             await _unitOfWork.SaveChangesAsync();
            return response;
        }

        public  async Task<bool> DeleteProduction(int id)
        {
            var series = _unitOfWork.SerieRepository.GetSeriesByProductionId(id);
            
            foreach(var item in series)
            {
                await _genreSerieRepository.RemoveRange(item.GenreSeries);
            }
            await _unitOfWork.SerieRepository.DeleteSerieByProductionId(id);
            var response = await _productionRepository.DeleteAsync(id);
            return response;
        }
    }
}
