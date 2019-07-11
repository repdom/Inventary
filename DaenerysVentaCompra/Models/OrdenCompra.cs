using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DaenerysVentaCompra.Models
{
    public class OrdenCompra
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("codigoCompra")]
        public string CodigoCompra { get; set; }

        [BsonElement("codigoSuplidor")]
        public string CodigoSuplidor { get; set; }

        [BsonElement("fechaOrden")]
        public String FechaOrden { get; set; }

        [BsonElement("montoTotal")]
        public double MontoTotal { get; set; }

        [BsonElement("articulos")]
        public List<ArticuloOrden> Articulos { get; set; }
    }
}
