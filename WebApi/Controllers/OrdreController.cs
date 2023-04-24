using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.I_R;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdreController : ControllerBase
    {
        private readonly IOrdre _ordreService;
        public OrdreController(IOrdre ordreService)
        {
            _ordreService = ordreService;
        }
        /// <summary>
        /// Get ordre and products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetOrdreById")]
        public IQueryable GetOrdreById(int id)
            => _ordreService.FindAll().Where(o => o.OrdreId == id).Include(o => o.Products);
    }
}
