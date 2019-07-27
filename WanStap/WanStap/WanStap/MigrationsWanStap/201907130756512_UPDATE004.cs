namespace WanStap.MigrationsWanStap
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE004 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "Id", c => c.String(nullable: false));
            DropColumn("dbo.Member", "IdentityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "IdentityId", c => c.Int(nullable: false));
            DropColumn("dbo.Member", "Id");
        }
    }
}
