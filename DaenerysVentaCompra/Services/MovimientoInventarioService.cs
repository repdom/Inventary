using System;
using DaenerysVentaCompra.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaenerysVentaCompra.Services
{
    public class MovimientoInventarioService
    {
        private readonly IMongoCollection<MovimientoInventario> _movimientoInventario;

        public MovimientoInventarioService(IInventoryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _movimientoInventario = database.GetCollection<MovimientoInventario>("movimientoInventario");
        }

        public List<MovimientoInventario> Get() =>
            _movimientoInventario.Find(movimientoInventario => true).ToList();

        public MovimientoInventario Get(string id) =>
            _movimientoInventario.Find<MovimientoInventario>(movimientoInventario => movimientoInventario.Id == id).FirstOrDefault();

        public MovimientoInventario Create(MovimientoInventario movimiento)
        {
            _movimientoInventario.InsertOne(movimiento);

            return movimiento;
        }

        public void Update(string id, MovimientoInventario movimiento) =>
            _movimientoInventario.ReplaceOne(mov => mov.Id == id, movimiento);

        public void Remove(MovimientoInventario movimiento) =>
            _movimientoInventario.DeleteOne(mov => mov.Id == movimiento.Id);

        public void Remove(string id) =>
            _movimientoInventario.DeleteOne(movimiento => movimiento.Id == id);

    }
}
