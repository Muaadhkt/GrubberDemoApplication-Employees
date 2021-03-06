namespace GrubberDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        PkEmployeeId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.String(),
                        Address = c.String(maxLength: 1000),
                        Role = c.String(),
                        Skills = c.String(),
                        About = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Hobbies = c.String(),
                        RowStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PkEmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
