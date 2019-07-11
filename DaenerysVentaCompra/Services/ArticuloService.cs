using System;
using DaenerysVentaCompra.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaenerysVentaCompra.Services
{
    public class ArticuloService
    {
        private readonly IMongoCollection<Articulo> _articulo;

        public ArticuloService(IInventoryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _articulo = database.GetCollection<Articulo>(settings.InventoryCollectionName);
        }

        public List<Articulo> Get() =>
            _articulo.Find(articulo => true).ToList();

        public Articulo Get(string id) =>
            _articulo.Find<Articulo>(articulo => articulo.Id == id).FirstOrDefault();

        public Articulo Create(Articulo articulo)
        {
            _articulo.InsertOne(articulo);

            return articulo;
        }

        public void Update(string id, Articulo articulo) =>
            _articulo.ReplaceOne(art => art.Id == id, articulo);

        public void Remove(Articulo articulo) =>
            _articulo.DeleteOne(art => art.Id == articulo.Id);

        public void Remove(string id) =>
            _articulo.DeleteOne(articulo => articulo.Id == id);
    }
}
