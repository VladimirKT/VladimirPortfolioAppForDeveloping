namespace VladimirKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMovieCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieCustomers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MovieCustomers", new[] { "CustomerId" });
            AddColumn("dbo.MovieCustomers", "Customers_Id", c => c.Int());
            AlterColumn("dbo.MovieCustomers", "CustomerId", c => c.String());
            CreateIndex("dbo.MovieCustomers", "Customers_Id");
            AddForeignKey("dbo.MovieCustomers", "Customers_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCustomers", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.MovieCustomers", new[] { "Customers_Id" });
            AlterColumn("dbo.MovieCustomers", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.MovieCustomers", "Customers_Id");
            CreateIndex("dbo.MovieCustomers", "CustomerId");
            AddForeignKey("dbo.MovieCustomers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
