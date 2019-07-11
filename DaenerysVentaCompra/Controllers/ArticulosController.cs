using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DaenerysVentaCompra.Models;
using DaenerysVentaCompra.Services;

namespace DaenerysVentaCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticuloService _articuloService;

        public ArticulosController(ArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet]
        public ActionResult<List<Articulo>> Get() =>
            _articuloService.Get();

        [HttpGet("{id:length(24)}", Name = "GetArticulo")]
        public ActionResult<Articulo> Get(string id)
        {
            var articulo = _articuloService.Get(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        [HttpPost]
        public ActionResult<Articulo> Create(Articulo articulo)
        {
            _articuloService.Create(articulo);

            return CreatedAtRoute("GetArticulo", new { id = articulo.Id.ToString() }, articulo);
        }

        [HttpPut]
        public ActionResult<Articulo> Replace(Articulo articulo)
        {
            _articuloService.Update(articulo.Id, articulo);

            return CreatedAtRoute("GetArticulo", new { id = articulo.Id.ToString(), articulo });
        }
    }
}