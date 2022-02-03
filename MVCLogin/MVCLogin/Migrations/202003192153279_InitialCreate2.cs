namespace MVCLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Files");
            AddColumn("dbo.Files", "No", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Files", "Reference", c => c.String());
            AddPrimaryKey("dbo.Files", "No");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Files");
            AlterColumn("dbo.Files", "Reference", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Files", "No");
            AddPrimaryKey("dbo.Files", "Reference");
        }
    }
}
