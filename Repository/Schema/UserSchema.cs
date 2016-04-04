using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.Entities;

namespace Repository.Schema
{
   public class UserSchema : EntityTypeConfiguration<User>
    {
       public UserSchema()
       {
           // Primary Key
           this.HasKey(t => t.UserId);

           // Properties

           // Table & Column Mappings
           this.ToTable("User");

           this.Property(t => t.UserId).HasColumnName("user_id");

           this.Property(t => t.HomeAddressId).HasColumnName("HomeAddress_Id");

           this.Property(t => t.OfficeAddressId).HasColumnName("OfficeAddress_id");

           this.Property(t => t.Name).HasColumnName("name");

           HasRequired(t => t.HomeAddress).WithMany(t => t.HomeAddressUser).HasForeignKey(t => t.HomeAddressId); // FK_dbo.order_dbo.address_delivery_address_id
           HasOptional(a => a.OfficeAddress).WithMany(b => b.OfficeAddressUser).HasForeignKey(c => c.OfficeAddressId); // FK_dbo.order_dbo.address_billing_address_id
       }
    }
}
