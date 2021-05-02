namespace bookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.Rents", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rents", "Book_Id", "dbo.Books");
            DropIndex("dbo.Rents", new[] { "User_Id" });
            DropIndex("dbo.Rents", new[] { "Book_Id" });
            DropTable("dbo.Rents");
        }
    }
}
