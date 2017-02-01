namespace STS.Ikar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeToDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CMRs", "CreateDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.CMRs", "PickupDate", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.CMRs", "DeliveryDate", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Drivers", "Birthday", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.WarehouseDocuments", "CreateDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.WarehouseDocuments", "ConfirmDate", c => c.DateTime(precision: 0, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WarehouseDocuments", "ConfirmDate", c => c.DateTime());
            AlterColumn("dbo.WarehouseDocuments", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Drivers", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CMRs", "DeliveryDate", c => c.DateTime());
            AlterColumn("dbo.CMRs", "PickupDate", c => c.DateTime());
            AlterColumn("dbo.CMRs", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
