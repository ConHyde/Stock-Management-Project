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
        public DateTime? UpdatedDate { get; set; }
        public bool Invalid { get; set; }

        public ProductCount(Guid guid,
                            Guid productGuid,
                            decimal quantity,
                            Guid userGuid,
                            DateTime createdDate,
                            DateTime? updatedDate,
                            bool invalid)
        {
            this.Guid = guid;
            this.ProductGuid = productGuid;
            this.Quantity = quantity;
            this.UserGuid = userGuid;
            this.CreatedDate = createdDate;
            this.UpdatedDate = UpdatedDate;
            this.Invalid = invalid;
        }
    }
}
