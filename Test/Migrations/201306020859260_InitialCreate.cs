namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        StuID = c.Int(nullable: false, identity: true),
                        course = c.String(),
                        seltime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StuID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentModels");
        }
    }
}
