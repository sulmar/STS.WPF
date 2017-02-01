namespace STS.Ikar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNumberCMR : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CMRs", "Number", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CMRs", "Number", c => c.String());
        }
    }
}
