namespace STS.Ikar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        Postcode = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .Index(t => t.Address_AddressId);
            
            CreateTable(
                "dbo.CMRs",
                c => new
                    {
                        CMRId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        PickupDate = c.DateTime(),
                        DeliveryDate = c.DateTime(),
                        ArrivalAddress_AddressId = c.Int(),
                        DeliveryAddress_AddressId = c.Int(),
                        Driver_DriverId = c.Int(),
                        Truck_TruckId = c.Int(),
                    })
                .PrimaryKey(t => t.CMRId)
                .ForeignKey("dbo.Addresses", t => t.ArrivalAddress_AddressId)
                .ForeignKey("dbo.Addresses", t => t.DeliveryAddress_AddressId)
                .ForeignKey("dbo.Drivers", t => t.Driver_DriverId)
                .ForeignKey("dbo.Trucks", t => t.Truck_TruckId)
                .Index(t => t.ArrivalAddress_AddressId)
                .Index(t => t.DeliveryAddress_AddressId)
                .Index(t => t.Driver_DriverId)
                .Index(t => t.Truck_TruckId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        NumberId = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        TruckId = c.Int(nullable: false, identity: true),
                        Plate = c.String(),
                        SideNumber = c.String(),
                    })
                .PrimaryKey(t => t.TruckId);
            
            CreateTable(
                "dbo.WarehouseDocuments",
                c => new
                    {
                        WarehouseDocumentId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        DocumentType = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ConfirmDate = c.DateTime(),
                        Vehicle_VehicleId = c.Int(),
                        CMR_CMRId = c.Int(),
                    })
                .PrimaryKey(t => t.WarehouseDocumentId)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_VehicleId)
                .ForeignKey("dbo.CMRs", t => t.CMR_CMRId)
                .Index(t => t.Vehicle_VehicleId)
                .Index(t => t.CMR_CMRId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        Mark = c.String(),
                        Model = c.String(),
                        VIN = c.String(),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarehouseDocuments", "CMR_CMRId", "dbo.CMRs");
            DropForeignKey("dbo.WarehouseDocuments", "Vehicle_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CMRs", "Truck_TruckId", "dbo.Trucks");
            DropForeignKey("dbo.CMRs", "Driver_DriverId", "dbo.Drivers");
            DropForeignKey("dbo.CMRs", "DeliveryAddress_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.CMRs", "ArrivalAddress_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Vehicles", new[] { "Customer_CustomerId" });
            DropIndex("dbo.WarehouseDocuments", new[] { "CMR_CMRId" });
            DropIndex("dbo.WarehouseDocuments", new[] { "Vehicle_VehicleId" });
            DropIndex("dbo.CMRs", new[] { "Truck_TruckId" });
            DropIndex("dbo.CMRs", new[] { "Driver_DriverId" });
            DropIndex("dbo.CMRs", new[] { "DeliveryAddress_AddressId" });
            DropIndex("dbo.CMRs", new[] { "ArrivalAddress_AddressId" });
            DropIndex("dbo.Customers", new[] { "Address_AddressId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.WarehouseDocuments");
            DropTable("dbo.Trucks");
            DropTable("dbo.Drivers");
            DropTable("dbo.CMRs");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
