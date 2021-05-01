namespace bookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            AddColumn("dbo.AspNetUsers", "LibraryCard", c => c.Byte(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Username", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            AlterColumn("dbo.AspNetUsers", "Username", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.AspNetUsers", "LibraryCard");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
        }
    }
}
