namespace bookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Isbn = c.String(nullable: false, maxLength: 20),
                        Price = c.Int(nullable: false),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Authors", "Book_Id", c => c.Int());
            AddColumn("dbo.Genres", "Book_Id", c => c.Int());
            CreateIndex("dbo.Authors", "Book_Id");
            CreateIndex("dbo.Genres", "Book_Id");
            AddForeignKey("dbo.Authors", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.Genres", "Book_Id", "dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Authors", "Book_Id", "dbo.Books");
            DropIndex("dbo.Genres", new[] { "Book_Id" });
            DropIndex("dbo.Authors", new[] { "Book_Id" });
            DropColumn("dbo.Genres", "Book_Id");
            DropColumn("dbo.Authors", "Book_Id");
            DropTable("dbo.Books");
        }
    }
}
