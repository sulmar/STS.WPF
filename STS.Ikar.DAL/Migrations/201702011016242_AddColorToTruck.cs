namespace STS.Ikar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorToTruck : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trucks", "Color", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trucks", "Color");
        }
    }
}
