using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ARMIES",
                columns: table => new
                {
                    ARMY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LABEL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARMIES", x => x.ARMY_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MEEPLES",
                columns: table => new
                {
                    MEEPLE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IMAGE_URL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ROW_INDEX = table.Column<int>(type: "int", nullable: false),
                    COLUMN_INDEX = table.Column<int>(type: "int", nullable: false),
                    ARMY_ID = table.Column<int>(type: "int", nullable: true),
                    MEEPLE_TYPE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEEPLES", x => x.MEEPLE_ID);
                    table.ForeignKey(
                        name: "FK_MEEPLES_ARMIES_ARMY_ID",
                        column: x => x.ARMY_ID,
                        principalTable: "ARMIES",
                        principalColumn: "ARMY_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MEEPLES_ARMY_ID",
                table: "MEEPLES",
                column: "ARMY_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEEPLES");

            migrationBuilder.DropTable(
                name: "ARMIES");
        }
    }
}
