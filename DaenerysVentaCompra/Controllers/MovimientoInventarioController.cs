using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DaenerysVentaCompra.Services;
using DaenerysVentaCompra.Models;

namespace DaenerysVentaCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoInventarioController : ControllerBase
    {
        private readonly MovimientoInventarioService _movimientoInventarioService;

        public MovimientoInventarioController(MovimientoInventarioService movimientoService)
        {
            _movimientoInventarioService = movimientoService;
        }

        [HttpGet]
        public ActionResult<List<MovimientoInventario>> Get() =>
            _movimientoInventarioService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMovimientoInventario")]
        public ActionResult<MovimientoInventario> Get(string id)
        {
            var movimiento = _movimientoInventarioService.Get(id);

            if (movimiento == null)
            {
                return NotFound();
            }

            return movimiento;
        }

        [HttpPost]
        public ActionResult<MovimientoInventario> Create([FromBody]MovimientoInventario movimiento)
        {
            _movimientoInventarioService.Create(movimiento);

            return CreatedAtRoute("GetMovimientoInventario", new { id = movimiento.Id.ToString() }, movimiento);
        }

    }
}