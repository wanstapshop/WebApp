namespace WanStap.MigrationsWanStap
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Establishment",
                c => new
                    {
                        EstablishmentID = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        Name = c.String(),
                        EstablishmentTypeID = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstablishmentID)
                .ForeignKey("dbo.EstablishmentType", t => t.EstablishmentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.EstablishmentTypeID);
            
            CreateTable(
                "dbo.EstablishmentType",
                c => new
                    {
                        EstablishmentTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstablishmentTypeID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        UserName = c.String(),
                        IdentityId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        MemberTypeId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.MemberType", t => t.MemberTypeId, cascadeDelete: true)
                .Index(t => t.MemberTypeId);
            
            CreateTable(
                "dbo.MemberType",
                c => new
                    {
                        MemberTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberTypeId);
            
            CreateTable(
                "dbo.Ride",
                c => new
                    {
                        RideID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        PlateNumber = c.String(),
                        BrandName = c.String(),
                        Make = c.String(),
                        Color = c.String(),
                        RideTypeID = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RideID)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.RideType", t => t.RideTypeID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.RideTypeID);
            
            CreateTable(
                "dbo.RideType",
                c => new
                    {
                        RideTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RideTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Establishment", "MemberId", "dbo.Member");
            DropForeignKey("dbo.Ride", "RideTypeID", "dbo.RideType");
            DropForeignKey("dbo.Ride", "MemberID", "dbo.Member");
            DropForeignKey("dbo.Member", "MemberTypeId", "dbo.MemberType");
            DropForeignKey("dbo.Establishment", "EstablishmentTypeID", "dbo.EstablishmentType");
            DropIndex("dbo.Ride", new[] { "RideTypeID" });
            DropIndex("dbo.Ride", new[] { "MemberID" });
            DropIndex("dbo.Member", new[] { "MemberTypeId" });
            DropIndex("dbo.Establishment", new[] { "EstablishmentTypeID" });
            DropIndex("dbo.Establishment", new[] { "MemberId" });
            DropTable("dbo.RideType");
            DropTable("dbo.Ride");
            DropTable("dbo.MemberType");
            DropTable("dbo.Member");
            DropTable("dbo.EstablishmentType");
            DropTable("dbo.Establishment");
        }
    }
}
