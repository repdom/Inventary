using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaenerysVentaCompra.Models
{
    public class ArticuloOrden
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("codigoArticulo")]
        public string CodigoArticulo { get; set; }

        [BsonElement("cantidadOrdenada")]
        public double cantidadOrdenada { get; set; }

        [BsonElement("unidad")]
        public string unidad { get; set; }

        [BsonElement("precio")]
        public double precio { get; set; }


    }
}
