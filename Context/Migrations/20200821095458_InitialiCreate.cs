using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class InitialiCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sort_name = table.Column<string>(nullable: true),
                    Begin_date_year = table.Column<int>(nullable: true),
                    Begin_date_month = table.Column<int>(nullable: true),
                    Begin_date_day = table.Column<int>(nullable: true),
                    End_date_year = table.Column<int>(nullable: true),
                    End_date_month = table.Column<int>(nullable: true),
                    End_date_day = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Area = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Edits_pending = table.Column<int>(nullable: true),
                    Last_updated = table.Column<DateTime>(nullable: true),
                    Ended = table.Column<bool>(nullable: false),
                    Begin_area = table.Column<int>(nullable: true),
                    End_area = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Artist_credit = table.Column<int>(nullable: false),
                    Release_group = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: true),
                    Packaging = table.Column<int>(nullable: true),
                    Language = table.Column<int>(nullable: true),
                    Script = table.Column<int>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Edits_pending = table.Column<int>(nullable: true),
                    Quality = table.Column<int>(nullable: true),
                    Last_updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Releases");
        }
    }
}
