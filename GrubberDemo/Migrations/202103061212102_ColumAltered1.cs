namespace GrubberDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumAltered1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "JoinDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "JoinDate", c => c.String());
            AlterColumn("dbo.Employees", "BirthDate", c => c.String());
        }
    }
}
