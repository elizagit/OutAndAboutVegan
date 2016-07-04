namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        Rating = c.Int(nullable: false),
                        NumberOfRatings = c.Int(nullable: false),
                        SumOfRatings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurant");
        }
    }
}
