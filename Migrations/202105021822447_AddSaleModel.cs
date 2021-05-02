namespace bookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSaleModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SaleType = c.Byte(nullable: false),
                        Amount = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sales", "Book_Id", "dbo.Books");
            DropIndex("dbo.Sales", new[] { "User_Id" });
            DropIndex("dbo.Sales", new[] { "Book_Id" });
            DropTable("dbo.Sales");
        }
    }
}
