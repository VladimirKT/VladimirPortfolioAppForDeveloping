namespace VladimirKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumnInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Director", c => c.String());
            DropColumn("dbo.Movies", "Directror");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Directror", c => c.String());
            DropColumn("dbo.Movies", "Director");
        }
    }
}
