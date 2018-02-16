namespace VladimirKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCustomers", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieCustomers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MovieCustomers", new[] { "MovieId" });
            DropIndex("dbo.MovieCustomers", new[] { "CustomerId" });
            DropTable("dbo.MovieCustomers");
        }
    }
}
