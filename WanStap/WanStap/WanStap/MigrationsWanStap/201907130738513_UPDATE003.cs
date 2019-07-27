namespace WanStap.MigrationsWanStap
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE003 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Establishment", "Name", c => c.String());
            AlterColumn("dbo.EstablishmentType", "Name", c => c.String());
            AlterColumn("dbo.EstablishmentType", "Description", c => c.String());
            AlterColumn("dbo.Member", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "PlateNumber", c => c.String());
            AlterColumn("dbo.Ride", "BrandName", c => c.String());
            AlterColumn("dbo.Ride", "Make", c => c.String());
            AlterColumn("dbo.Ride", "Color", c => c.String());
            AlterColumn("dbo.RideType", "Name", c => c.String());
            AlterColumn("dbo.RideType", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RideType", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.RideType", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "BrandName", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "PlateNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.EstablishmentType", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.EstablishmentType", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Establishment", "Name", c => c.String(nullable: false));
        }
    }
}
