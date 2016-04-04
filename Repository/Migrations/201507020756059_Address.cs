namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        HomeAddress_Id = c.Int(nullable: false),
                        OfficeAddress_id = c.Int(),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("dbo.Address", t => t.HomeAddress_Id, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.OfficeAddress_id)
                .Index(t => t.HomeAddress_Id)
                .Index(t => t.OfficeAddress_id);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        HouseNumber = c.String(maxLength: 255),
                        AddressLine1 = c.String(maxLength: 2000),
                        AddressLine2 = c.String(maxLength: 255),
                        TownOrCity = c.String(maxLength: 255),
                        CountyOrProvince = c.String(maxLength: 255),
                        ZipCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 255),
                        MobileNumber = c.String(maxLength: 50),
                        ModifiedDateTime = c.DateTime(),
                        NickName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "OfficeAddress_id", "dbo.Address");
            DropForeignKey("dbo.User", "HomeAddress_Id", "dbo.Address");
            DropIndex("dbo.User", new[] { "OfficeAddress_id" });
            DropIndex("dbo.User", new[] { "HomeAddress_Id" });
            DropTable("dbo.Address");
            DropTable("dbo.User");
        }
    }
}
