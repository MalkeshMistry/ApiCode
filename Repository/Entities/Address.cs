using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Address
    {
        /// <summary>
        /// Gets or sets Address Id 
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the House Number
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the Address line1
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the Address line2
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the town or city
        /// </summary>
        public string TownOrCity { get; set; }

        /// <summary>
        /// Gets or sets the County or Province
        /// </summary>
        public string CountyOrProvince { get; set; }

        /// <summary>
        /// Gets or sets the Zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the Mobile number
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the Modified Date time
        /// </summary>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Nick Name
        /// </summary>
        public string NickName { get; set; }


        /// <summary>
        /// Gets or sets the delivery address order.
        /// </summary>
        public virtual ICollection<User> HomeAddressUser { get; set; }

        /// <summary>
        /// Gets or sets the billing address order.
        /// </summary>
        public virtual ICollection<User> OfficeAddressUser { get; set; }
    }
}
