using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.Entities;

namespace Repository.Schema
{
    public class CustomerSchema : EntityTypeConfiguration<CustomerEntity>
    {
        public CustomerSchema()
        {
            // Primary Key
            this.HasKey(t => t.CustomerId);

            // Properties

            // Table & Column Mappings
            this.ToTable("customer");

            this.Property(t => t.CustomerId).HasColumnName("customer_id");

            this.Property(t => t.CustomerName).HasColumnName("customer_name");

            this.Property(t => t.CustomerAddress).HasColumnName("customer_address");

            this.Property(t => t.CustomerContactNumner).HasColumnName("customer_contact_number");
        }
    }
}
