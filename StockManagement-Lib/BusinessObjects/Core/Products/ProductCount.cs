using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement_Lib
{
    public class ProductCount
    {
        public Guid Guid { get; set; }
        public Guid ProductGuid { get; set; }
        public Decimal Quantity { get; set; }
        public Guid UserGuid { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Inactive { get; set; }

        public ProductCount(Guid guid,
                            Guid productGuid,
                            decimal quantity,
                            Guid userGuid,
                            DateTime createdDate,
                            bool inactive)
        {
            this.Guid = guid;
            this.ProductGuid = productGuid;
            this.Quantity = quantity;
            this.UserGuid = userGuid;
            this.CreatedDate = createdDate;
            this.Inactive = inactive;
        }
    }
}
