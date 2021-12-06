using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement_Lib
{
    public class Stock
    {
        public Guid Guid { get; set; }
        public Guid ProductGuid { get; set; }
        public Guid LocationGuid { get; set; }
        public Decimal Quantity { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
