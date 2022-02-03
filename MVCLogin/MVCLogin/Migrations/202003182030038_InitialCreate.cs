namespace MVCLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Reference = c.String(nullable: false, maxLength: 128),
                        Attorney = c.String(),
                        ClaimentName = c.String(),
                        ClaimentSurname = c.String(),
                        ClaimentID = c.String(),
                    })
                .PrimaryKey(t => t.Reference);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Files");
        }
    }
}
