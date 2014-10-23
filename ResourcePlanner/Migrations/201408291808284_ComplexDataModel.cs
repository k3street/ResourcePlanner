namespace ResourcePlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "BusinessUnit_BusinessUnitId", "dbo.BusinessUnits");
            DropIndex("dbo.Departments", new[] { "BusinessUnit_BusinessUnitId" });
            RenameColumn(table: "dbo.Departments", name: "BusinessUnit_BusinessUnitId", newName: "BusinessUnitID");
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        WorkingHours = c.String(),
                        TimeZone = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Role_RoleId = c.Int(),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Role_RoleId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
            AddForeignKey("dbo.Departments", "BusinessUnitID", "dbo.BusinessUnits", "BusinessUnitId", cascadeDelete: true);
            CreateIndex("dbo.Departments", "BusinessUnitID");
            DropColumn("dbo.BusinessUnits", "DepartmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BusinessUnits", "DepartmentID", c => c.Int());
            DropIndex("dbo.Roles", new[] { "Department_DepartmentId" });
            DropIndex("dbo.People", new[] { "Department_DepartmentId" });
            DropIndex("dbo.People", new[] { "Role_RoleId" });
            DropIndex("dbo.Departments", new[] { "BusinessUnitID" });
            DropForeignKey("dbo.Roles", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.People", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.People", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Departments", "BusinessUnitID", "dbo.BusinessUnits");
            DropTable("dbo.Roles");
            DropTable("dbo.People");
            RenameColumn(table: "dbo.Departments", name: "BusinessUnitID", newName: "BusinessUnit_BusinessUnitId");
            CreateIndex("dbo.Departments", "BusinessUnit_BusinessUnitId");
            AddForeignKey("dbo.Departments", "BusinessUnit_BusinessUnitId", "dbo.BusinessUnits", "BusinessUnitId");
        }
    }
}
