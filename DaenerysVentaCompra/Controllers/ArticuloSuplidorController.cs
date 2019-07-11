using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaenerysVentaCompra.Models;
using DaenerysVentaCompra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaenerysVentaCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloSuplidorController : ControllerBase
    {
        private readonly ArticuloSuplidorService _articuloSupService;

        public ArticuloSuplidorController(ArticuloSuplidorService articuloService)
        {
            _articuloSupService = articuloService;
        }

        // GET: api/ArticuloSuplidor
        [HttpGet]
        public ActionResult<List<ArticuloSuplidor>> Get() =>
           _articuloSupService.Get();

        //HttpGet("{id:length(24)}", Name = "GetArticulo")]
        //public ActionResult<Articulo> returnSuplidor(string articuloid)
        //{

        //}


        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloSuplidor>> GetAsync(string id)
        {
          //  ArticuloSuplidor suplidor;
            Task<ArticuloSuplidor> suplidor = _articuloSupService.GetAsync(id);
            ArticuloSuplidor sup = await suplidor;
            if (sup == null)
            {
                return NotFound();
            }

            return sup;
        }

        // POST: api/ArticuloSuplidor
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/ArticuloSuplidor/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
