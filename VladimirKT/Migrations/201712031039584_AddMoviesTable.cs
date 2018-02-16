namespace VladimirKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Name = c.String(),
                        Year = c.String(),
                        Price = c.String(),
                        Description = c.String(),
                        Directror = c.String(),
                        Actors = c.String(),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
