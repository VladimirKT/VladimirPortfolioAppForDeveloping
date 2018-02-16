namespace VladimirKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ImagePath", c => c.String(maxLength: 255));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Year", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Price", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false, maxLength: 755));
            AlterColumn("dbo.Movies", "Director", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Actors", c => c.String(nullable: false, maxLength: 555));
            AlterColumn("dbo.Movies", "Duration", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "Duration", c => c.String());
            AlterColumn("dbo.Movies", "Actors", c => c.String());
            AlterColumn("dbo.Movies", "Director", c => c.String());
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "Price", c => c.String());
            AlterColumn("dbo.Movies", "Year", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AlterColumn("dbo.Movies", "ImagePath", c => c.String());
        }
    }
}
