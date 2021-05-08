namespace bookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuthor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "Book_Id", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "Book_Id" });
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Author_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Author_Id);
            
            DropColumn("dbo.Authors", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Book_Id", c => c.Int());
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_Id" });
            DropTable("dbo.BookAuthors");
            CreateIndex("dbo.Authors", "Book_Id");
            AddForeignKey("dbo.Authors", "Book_Id", "dbo.Books", "Id");
        }
    }
}
