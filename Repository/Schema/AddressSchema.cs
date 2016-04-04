using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.Entities;

namespace Repository.Schema
{
    public class AddressSchema : EntityTypeConfiguration<Address>
    {
        public AddressSchema()
       {
           // Primary Key
           this.HasKey(t => t.AddressId);

           // Properties

           // Table & Column Mappings
           this.ToTable("Address");

           Property(t => t.AddressId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           Property(t => t.Name).IsOptional().HasMaxLength(255);
           Property(t => t.HouseNumber).IsOptional().HasMaxLength(255);
           Property(t => t.AddressLine1).IsOptional().HasMaxLength(2000);
           Property(t => t.AddressLine2).IsOptional().HasMaxLength(255);
           Property(t => t.TownOrCity).IsOptional().HasMaxLength(255);
           Property(t => t.CountyOrProvince).IsOptional().HasMaxLength(255);
           Property(t => t.ZipCode).IsOptional().HasMaxLength(10);
           Property(t => t.Country).IsOptional().HasMaxLength(255);
           Property(t => t.MobileNumber).IsOptional().HasMaxLength(50);
           Property(t => t.ModifiedDateTime).IsOptional();
           Property(t => t.NickName).IsOptional().HasMaxLength(255);
       }
    }
}
