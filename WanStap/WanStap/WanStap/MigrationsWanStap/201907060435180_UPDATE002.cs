namespace WanStap.MigrationsWanStap
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE002 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Establishment", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.EstablishmentType", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.EstablishmentType", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.MemberType", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MemberType", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "PlateNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "BrandName", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Ride", "Capacity", c => c.Int());
            AlterColumn("dbo.RideType", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RideType", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RideType", "Description", c => c.String());
            AlterColumn("dbo.RideType", "Name", c => c.String());
            AlterColumn("dbo.Ride", "Capacity", c => c.Int(nullable: false));
            AlterColumn("dbo.Ride", "Color", c => c.String());
            AlterColumn("dbo.Ride", "Make", c => c.String());
            AlterColumn("dbo.Ride", "BrandName", c => c.String());
            AlterColumn("dbo.Ride", "PlateNumber", c => c.String());
            AlterColumn("dbo.MemberType", "Description", c => c.String());
            AlterColumn("dbo.MemberType", "Name", c => c.String());
            AlterColumn("dbo.Member", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Member", "UserName", c => c.String());
            AlterColumn("dbo.Member", "LastName", c => c.String());
            AlterColumn("dbo.Member", "FirstName", c => c.String());
            AlterColumn("dbo.EstablishmentType", "Description", c => c.String());
            AlterColumn("dbo.EstablishmentType", "Name", c => c.String());
            AlterColumn("dbo.Establishment", "Name", c => c.String());
        }
    }
}
