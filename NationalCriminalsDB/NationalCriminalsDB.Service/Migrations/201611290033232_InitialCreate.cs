namespace NationalCriminalsDB.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Crimes",
                c => new
                    {
                        CrimeID = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Victime = c.String(),
                        Time = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CrimeID);
            
            CreateTable(
                "dbo.Criminals",
                c => new
                    {
                        CriminalId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Photo = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                        Nationality = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CriminalId);
            
            CreateTable(
                "dbo.CriminalCrime",
                c => new
                    {
                        CriminalId = c.Guid(nullable: false),
                        CrimeID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CriminalId, t.CrimeID })
                .ForeignKey("dbo.Criminals", t => t.CriminalId, cascadeDelete: true)
                .ForeignKey("dbo.Crimes", t => t.CrimeID, cascadeDelete: true)
                .Index(t => t.CriminalId)
                .Index(t => t.CrimeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CriminalCrime", "CrimeID", "dbo.Crimes");
            DropForeignKey("dbo.CriminalCrime", "CriminalId", "dbo.Criminals");
            DropIndex("dbo.CriminalCrime", new[] { "CrimeID" });
            DropIndex("dbo.CriminalCrime", new[] { "CriminalId" });
            DropTable("dbo.CriminalCrime");
            DropTable("dbo.Criminals");
            DropTable("dbo.Crimes");
        }
    }
}
