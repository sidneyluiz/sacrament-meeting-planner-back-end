using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SacramentMeeting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Conductor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    OpeningHymn = table.Column<int>(nullable: false),
                    OpeningPlayer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SacramentHymn = table.Column<int>(nullable: false),
                    ClosingHymn = table.Column<int>(nullable: false),
                    ClosingPlayer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Topic1 = table.Column<string>(type: "varchar(100)", nullable: true),
                    Topic2 = table.Column<string>(type: "varchar(100)", nullable: true),
                    Topic3 = table.Column<string>(type: "varchar(100)", nullable: true),
                    Speaker1Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Speaker2Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Speaker3Name = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentMeeting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SacramentMeeting");
        }
    }
}
