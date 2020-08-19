using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtistData.Migrations
{
    public partial class ReleaseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Releases");
        }
    }
}
