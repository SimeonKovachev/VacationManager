namespace VacationManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using VacationManager.Enums;

    public partial class VacationTypeENum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vacations", "Type", c => c.Int(nullable: false, defaultValue: (int)VacationTypeEnum.Paid));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vacations", "Type", c => c.String());
        }
    }
}
