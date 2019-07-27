namespace WanStap.MigrationsWanStap
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE006 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Establishment", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Establishment", "ModifiedBy", c => c.Int(nullable: false));
        }
    }
}
