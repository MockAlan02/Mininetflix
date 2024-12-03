using Microsoft.AspNetCore.Mvc;
using MiniNetflix.Core.Dto;
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Helper.Pagination;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.Core.Interface.Services;
using MiniNetflix.Presentation.ViewModelError;
using WebApplication1.ViewModelError;

namespace MiniNetflix.Presentation.Controllers
{
    public class MiniNetflixController : Controller
    {
        private readonly ISerieService? _serieService;
        private readonly IGenreSerieRepository _genreSerieRepository;
        public MiniNetflixController(ISerieService serieService, IGenreSerieRepository genreSerieRepository)
        {
            _serieService = serieService;
            _genreSerieRepository = genreSerieRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Serie() {

            return View();
        }
        public IActionResult CreateSerie()
        {
            return View("Crear/Serie/CreateSerie", new SerieDtoViewModel() );
        }
        public IActionResult CreatProduction()
        {
            return View("Crear/Serie/CreatProduction", new PersonaViewModel());
        }

        public async Task<IActionResult> Detail(int id)
        {
            var serie = await _serieService!.GetSerieWithGenre(id);
            return View(serie);
        }

        public async Task<IActionResult> UpdateSerie(int id)
        {
            var serie = await _serieService!.GetSerieWithGenre(id);
            ViewBag.Serie = serie;
            return View(new SerieDtoViewModel());
        }


        public IActionResult Filter([FromQuery] Filtered filtered)
        {
            var response = _serieService?.GetAllSerie(filtered);
            List<SerieWithGenresDto> ser = new();
            foreach(var serie in response!.Items)
            {
                ser.Add(new SerieWithGenresDto
                {
                    Serie = serie,
                    Genres = _genreSerieRepository.GetAllGenreSerieBySerieId(serie.Id)
                });
            }
            return Ok(ser);
        }
     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie([FromQuery]int id)
        {
            var response = await _serieService!.DeleteSerie(id);
            if(response){
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PutSerie([FromBody] SerieDto serie)
        {
            var response = await _serieService!.UpdateSerie(serie);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreatSerie([FromBody] SerieDto serie)
        {
            if(serie.GenresId == null)
            {
                return BadRequest();
            }
            _serieService!.AddSerie(serie);
            return Ok(new { response = true});
        }
    }
}
