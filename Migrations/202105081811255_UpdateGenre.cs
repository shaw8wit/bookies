namespace bookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Book_Id", "dbo.Books");
            DropIndex("dbo.Genres", new[] { "Book_Id" });
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Book_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Genres", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Book_Id", c => c.Int());
            DropForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.GenreBooks", new[] { "Book_Id" });
            DropIndex("dbo.GenreBooks", new[] { "Genre_Id" });
            DropTable("dbo.GenreBooks");
            CreateIndex("dbo.Genres", "Book_Id");
            AddForeignKey("dbo.Genres", "Book_Id", "dbo.Books", "Id");
        }
    }
}
