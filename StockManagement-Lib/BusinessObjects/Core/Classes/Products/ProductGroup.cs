using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement_Lib
{
    public class ProductGroup
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Inactive { get; set; }

        public ProductGroup(Guid guid,
                            string name,
                            string description,
                            bool inactive)
        {
            this.Guid = guid;
            this.Name = name;
            this.Description = description;
            this.Inactive = inactive;
        }
    }
}
