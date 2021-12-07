using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement_Lib
{
    public class Location
    {
        public Guid Guid { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserGuid { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedByUserGuid { get; set; }
        public bool Inactive { get; set; }

        public Location(Guid guid,
                        string iD,
                        string description,
                        DateTime created,
                        Guid createdByUserGuid,
                        DateTime? updatedDate,
                        Guid? updatedByUserGuid,
                        bool inactive)
        {
            this.Guid = guid;
            this.ID = iD;
            this.Description = description;
            this.CreatedDate = created;
            this.CreatedByUserGuid = createdByUserGuid;
            this.UpdatedDate = updatedDate;
            this.UpdatedByUserGuid = updatedByUserGuid;
            this.Inactive = inactive;
        }
    }
}
