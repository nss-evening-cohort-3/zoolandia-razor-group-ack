namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        AnimalName = c.String(nullable: false),
                        AnimalAge = c.Int(nullable: false),
                        SpeciesCommonName = c.String(),
                        SpeciesScientificName = c.String(nullable: false),
                        Habitat_HabitatId = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Habitats", t => t.Habitat_HabitatId)
                .Index(t => t.Habitat_HabitatId);
            
            CreateTable(
                "dbo.Habitats",
                c => new
                    {
                        HabitatId = c.Int(nullable: false, identity: true),
                        HabitatName = c.String(nullable: false),
                        HabitatType_HabitatTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.HabitatId)
                .ForeignKey("dbo.HabitatTypes", t => t.HabitatType_HabitatTypeId)
                .Index(t => t.HabitatType_HabitatTypeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeAge = c.Int(nullable: false),
                        EmployeeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.HabitatTypes",
                c => new
                    {
                        HabitatTypeId = c.Int(nullable: false, identity: true),
                        HabitatTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HabitatTypeId);
            
            CreateTable(
                "dbo.EmployeeHabitats",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Habitat_HabitatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Habitat_HabitatId })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Habitats", t => t.Habitat_HabitatId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Habitat_HabitatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Habitats", "HabitatType_HabitatTypeId", "dbo.HabitatTypes");
            DropForeignKey("dbo.EmployeeHabitats", "Habitat_HabitatId", "dbo.Habitats");
            DropForeignKey("dbo.EmployeeHabitats", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Animals", "Habitat_HabitatId", "dbo.Habitats");
            DropIndex("dbo.EmployeeHabitats", new[] { "Habitat_HabitatId" });
            DropIndex("dbo.EmployeeHabitats", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Habitats", new[] { "HabitatType_HabitatTypeId" });
            DropIndex("dbo.Animals", new[] { "Habitat_HabitatId" });
            DropTable("dbo.EmployeeHabitats");
            DropTable("dbo.HabitatTypes");
            DropTable("dbo.Employees");
            DropTable("dbo.Habitats");
            DropTable("dbo.Animals");
        }
    }
}
