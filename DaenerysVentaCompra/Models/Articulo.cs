using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DaenerysVentaCompra.Models
{
    public class Articulo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("codigoArticulo")]
        public string CodigoArticulo { get; set; }
        [BsonElement("decripcion")]
        public string Descripcion { get; set; }
        [BsonElement("unidadCompra")]
        public string UnidadCompra { get; set; }
        [BsonElement("almacen")]    
        public List<BsonDocument> Almacen { get; set; }



    }
}
