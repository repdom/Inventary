using DaenerysVentaCompra.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaenerysVentaCompra.Services
{
    public class ArticuloSuplidorService
    {
        private readonly IMongoCollection<ArticuloSuplidor> _articuloSup;
        public ArticuloSuplidorService(IInventoryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _articuloSup = database.GetCollection<ArticuloSuplidor>("inventory.articuloSuplidor");
        }

        public async Task<ArticuloSuplidor> GetAsync(string articulo)
        {
            ArticuloSuplidor result = new ArticuloSuplidor();
          await _articuloSup.Aggregate().Match(z => z.codigoArticulo == articulo)
             .Group(
             new BsonDocument {
               { "_id", new BsonDocument{{ "arti", "$codigoArticulo" }, { "sup", "$codigoSupidor" } } },
               { "minQuantity", new BsonDocument("$min", "$tiempoEntrega") },
               { "minVal", new BsonDocument("$min", "$precioCompra") }
             })
             .Limit(1)
             .ForEachAsync(bson =>
              {
                  var symbolData = bson["_id"];
                  var minQ = bson["minQuantity"];
                  var minV = bson["minVal"];
                  result.codigoArticulo = symbolData["arti"].AsString;
                  result.codigoSupidor = symbolData["sup"].AsString;
                  result.precioCompra = minQ.AsDouble;
                  result.tiempoEntrega = minV.AsDouble;
              } );
       

        return result;

        }

    public List<ArticuloSuplidor> Get() =>
          _articuloSup.Find(articulo => true).ToList();

    //internal ActionResult<List<ArticuloSuplidor>> Get(string id)
    //{
    //    throw new NotImplementedException();
    //}
}
}
