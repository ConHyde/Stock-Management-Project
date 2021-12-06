using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement_Lib
{
    public class Product    
    {
        public Guid Guid { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ProductGroup { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserGuid { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedByUserGuid { get; set; }
        public DateTime? LastCounted { get; set; }
        public DateTime? LastCountedUserGuid { get; set; }
        public Decimal LastCostPrice { get; set; }
        public Decimal SalePrice { get; set; }
        public bool Inactive { get; set; }

    }
}    