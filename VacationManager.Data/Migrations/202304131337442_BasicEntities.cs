namespace VacationManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leaders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Age = c.Int(nullable: false),
                        Profession = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProjectID = c.Int(nullable: false),
                        LeaderID = c.Int(nullable: false),
                        WorkerID = c.Int(nullable: false),
                        NumOfWorkers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Leaders", t => t.LeaderID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.LeaderID)
                .Index(t => t.WorkerID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Age = c.Int(nullable: false),
                        Profession = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vacations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "WorkerID", "dbo.Workers");
            DropForeignKey("dbo.Teams", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Teams", "LeaderID", "dbo.Leaders");
            DropIndex("dbo.Teams", new[] { "WorkerID" });
            DropIndex("dbo.Teams", new[] { "LeaderID" });
            DropIndex("dbo.Teams", new[] { "ProjectID" });
            DropTable("dbo.Vacations");
            DropTable("dbo.Workers");
            DropTable("dbo.Projects");
            DropTable("dbo.Teams");
            DropTable("dbo.Leaders");
        }
    }
}
