namespace GrubberDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumAltered : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "BirthDate", c => c.String());
            AlterColumn("dbo.Employees", "JoinDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "JoinDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
