namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customer",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        customer_name = c.String(),
                        customer_address = c.String(),
                        customer_contact_number = c.String(),
                    })
                .PrimaryKey(t => t.customer_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.customer");
        }
    }
}
