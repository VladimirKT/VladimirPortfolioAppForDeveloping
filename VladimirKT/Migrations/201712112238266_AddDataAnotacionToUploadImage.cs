namespace VladimirKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnotacionToUploadImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ImagePath", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ImagePath", c => c.String(maxLength: 255));
        }
    }
}
