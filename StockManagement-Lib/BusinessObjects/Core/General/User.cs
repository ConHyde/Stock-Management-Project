using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement_Lib
{
    public class User
    {
        public Guid Guid { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsAdmin { get; set; }
        public bool Inactive { get; set; }

        public User(Guid guid,
                    string iD,
                    string firstName, 
                    string lastName, 
                    DateTime createdDate, 
                    DateTime? updatedDate, 
                    bool isAdmin, 
                    bool inactive)
        {
            this.Guid = guid;
            this.ID = iD;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CreatedDate = createdDate;
            this.UpdatedDate = updatedDate;
            this.IsAdmin = isAdmin;
            this.Inactive = inactive;
        }
    }
}
