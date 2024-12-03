using Microsoft.AspNetCore.Mvc;
using MiniNetflix.Core.Entities;
using MiniNetflix.Core.Interface.Services;

namespace MiniNetflix.Presentation.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionService _productionService;
        
        public ProductionController(IProductionService productionService)
        {
            _productionService = productionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatProduction()
        {
            return View("Crear/CreateProduction");
        }

    
        public async Task<IActionResult> Update(int id)
         {
            var data = await _productionService.GetProduction(id);
            ViewBag.Production = data;
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduction([FromBody]Production production)
        {
            _productionService.AddProduction(production);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduction([FromBody]Production production)
        {
            var response = await _productionService.UpdateProduction(production);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduction(int id)
        {
                
            var reponse = await _productionService.DeleteProduction(id);
            return Ok(reponse);
        }
    }
}
