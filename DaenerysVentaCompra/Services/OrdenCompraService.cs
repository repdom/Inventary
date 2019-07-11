using DaenerysVentaCompra.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaenerysVentaCompra.Services
{
    public class OrdenCompraService
    {
        private readonly IMongoCollection<OrdenCompra> _ordenCompra;
        public OrdenCompraService(IInventoryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ordenCompra = database.GetCollection<OrdenCompra>("inventory.ordenCompra");
        }
        public List<OrdenCompra> Get() =>
           _ordenCompra.Find(articulo => true).ToList();

        public OrdenCompra Get(string id) =>
            _ordenCompra.Find<OrdenCompra>(articulo => articulo.Id == id).FirstOrDefault();

        public OrdenCompra Create(OrdenCompra articulo)
        {
            _ordenCompra.InsertOne(articulo);

            return articulo;
        }

    }
}
