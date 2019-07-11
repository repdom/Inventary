using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DaenerysVentaCompra.Models
{
    public class MovimientoInventario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("codigoMovimiento")]
        public double CodigoMovimiento { get; set; }
        [BsonElement("codigoAlmacen")]
        public string CodigoAlmacen { get; set; }
        [BsonElement("tipoMovimiento")]
        public string TipoMovimiento { get; set; }
        [BsonElement("codigoArticulo")]
        public string codigoArticulo { get; set; }
        [BsonElement("cantidad")]
        public double Cantidad { get; set; }
        [BsonElement("unidad")]
        public string Unidad { get; set; }
    }
}
