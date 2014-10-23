namespace ResourcePlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusinessUnits", "BusinessUnitId", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BusinessUnits", "BusinessUnitId", c => c.Int(nullable: false));
        }
    }
}
