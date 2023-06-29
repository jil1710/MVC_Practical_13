namespace MVC_Practical_13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: true, identity: true),
                        Name = c.String(nullable: true, maxLength: 50),
                        DOB = c.DateTime(nullable: true, storeType: "date"),
                        Age = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
