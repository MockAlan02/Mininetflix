using Microsoft.AspNetCore.Mvc;
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface.Services;

namespace MiniNetflix.Presentation.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateGenre()
        {
          
            return View("Create/CreateGenre");
        }
        public IActionResult Detail(int id)
        {
            var response = _genreService.GetGenre(id);
            return View(response);
        }
        public async Task<IActionResult> Update(int id)
        {
            var data = await _genreService.GetGenre(id);
            ViewBag.Genre = data;
            return View("Update/update");
        }
        [HttpPost]
        public IActionResult CreateGenre([FromBody] Genre genre)
        {
            _genreService.AddGenre(genre);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGenre([FromBody]Genre genre)
        {
            var response = await _genreService.UpdateGenre(genre);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
         var response = await _genreService.DeleteGenre(id); 
            return Ok(response);
        }
    }
}
