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

        public Product(Guid guid, 
                       string iD,
                       string name,
                       string description,
                       Guid? productGroup,
                       DateTime createdDate,
                       Guid createdByUserGuid,
                       DateTime? updatedDate,
                       Guid? updatedByUserGuid,
                       DateTime? lastCounted,
                       DateTime? lastCountedUserGuid,
                       decimal lastCostPrice,
                       decimal salePrice,
                       bool inactive)
        {
            this.Guid = guid;
            this.ID = iD;
            this.Name = name;
            this.Description = description;
            this.ProductGroup = productGroup;
            this.CreatedDate = createdDate;
            this.CreatedByUserGuid = createdByUserGuid;
            this.UpdatedDate = updatedDate;
            this.UpdatedByUserGuid = updatedByUserGuid;
            this.LastCounted = lastCounted;
            this.LastCountedUserGuid = lastCountedUserGuid;
            this.LastCostPrice = lastCostPrice;
            this.SalePrice = salePrice;
            this.Inactive = inactive;
        }


    }
}    