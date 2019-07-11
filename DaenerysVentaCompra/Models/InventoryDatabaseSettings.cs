using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaenerysVentaCompra.Models
{
    public class InventoryDatabaseSettings : IInventoryDatabaseSettings
    {
        public string InventoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IInventoryDatabaseSettings
    {
        string InventoryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
