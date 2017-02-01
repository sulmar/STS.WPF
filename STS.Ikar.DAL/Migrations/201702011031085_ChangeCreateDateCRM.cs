namespace STS.Ikar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCreateDateCRM : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CMRs", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CMRs", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
