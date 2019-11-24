namespace WcfNumberConverter_lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ArabicNumber = c.Double(nullable: false),
                        RomanNumber = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                        Time = c.String(nullable: false),
                        UsersRequests_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsersRequests_Id)
                .Index(t => t.UsersRequests_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "UsersRequests_Id", "dbo.Users");
            DropIndex("dbo.Requests", new[] { "UsersRequests_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Requests");
        }
    }
}
