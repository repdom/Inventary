using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaenerysVentaCompra.Models
{
    public class ArticuloSuplidor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("codigoSupidor")]
        public string codigoSupidor { get; set; }

        [BsonElement("codigoArticulo")]
        public string codigoArticulo { get; set; }

        [BsonElement("tiempoEntrega")]
        public double tiempoEntrega { get; set; }

        [BsonElement("precioCompra")]
        public double precioCompra { get; set; }
    }
}

