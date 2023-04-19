namespace VacationManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VacationWorkerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacations", "WorkerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Vacations", "WorkerID");
            AddForeignKey("dbo.Vacations", "WorkerID", "dbo.Workers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacations", "WorkerID", "dbo.Workers");
            DropIndex("dbo.Vacations", new[] { "WorkerID" });
            DropColumn("dbo.Vacations", "WorkerID");
        }
    }
}
