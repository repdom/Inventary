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
    public class OrdenCompraController : ControllerBase
    {

        private readonly OrdenCompraService _ordenService;

        public OrdenCompraController(OrdenCompraService articuloService)
        {
            _ordenService = articuloService;
        }

        // GET: api/OrdenCompra
        [HttpGet]
        public ActionResult<List<OrdenCompra>> Get() =>
            _ordenService.Get();


        [HttpGet("{id:length(24)}", Name = "GetOrden")]
        public ActionResult<OrdenCompra> Get(string id)
        {
            var articulo = _ordenService.Get(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        [HttpPost]
        public ActionResult<OrdenCompra> Create(OrdenCompra articulo)
        {
            _ordenService.Create(articulo);

            return CreatedAtRoute("GetOrden", new { id = articulo.Id.ToString() }, articulo);
        }

    }
}
