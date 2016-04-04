using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public int HomeAddressId { get; set; }

        public int? OfficeAddressId { get; set; }

        public virtual Address HomeAddress { get; set; }

        public virtual Address OfficeAddress { get; set; }
    }
}
