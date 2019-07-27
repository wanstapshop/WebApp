namespace WanStap.MigrationsWanStap
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE005 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.MemberType", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.MemberType", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MemberType", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.MemberType", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Member", "ModifiedBy", c => c.Int(nullable: false));
        }
    }
}
