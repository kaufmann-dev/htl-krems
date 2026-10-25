using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CHATS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AUTO_DELETE_DURATION = table.Column<int>(type: "int", maxLength: 31536000, nullable: false),
                    PGP_ENFORCEMENT = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHATS", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TAG = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PASSWORD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    XMR_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PGP_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PGP_PUBLIC_KEYS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KEY = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE_DATE = table.Column<DateOnly>(type: "date", nullable: false),
                    ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PGP_PUBLIC_KEYS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PGP_PUBLIC_KEYS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USER_SUBSCRIBED_CHATS",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CHAT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_SUBSCRIBED_CHATS", x => new { x.CHAT_ID, x.USER_ID });
                    table.ForeignKey(
                        name: "FK_USER_SUBSCRIBED_CHATS_CHATS_CHAT_ID",
                        column: x => x.CHAT_ID,
                        principalTable: "CHATS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_SUBSCRIBED_CHATS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "XMR_RECEIVE_ADDRESSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ADDRESS = table.Column<string>(type: "varchar(106)", maxLength: 106, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDED = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XMR_RECEIVE_ADDRESSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_XMR_RECEIVE_ADDRESSES_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PGP_PUBLIC_KEYS_USER_ID",
                table: "PGP_PUBLIC_KEYS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_SUBSCRIBED_CHATS_USER_ID",
                table: "USER_SUBSCRIBED_CHATS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_TAG",
                table: "USERS",
                column: "TAG",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_XMR_RECEIVE_ADDRESSES_USER_ID",
                table: "XMR_RECEIVE_ADDRESSES",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PGP_PUBLIC_KEYS");

            migrationBuilder.DropTable(
                name: "USER_SUBSCRIBED_CHATS");

            migrationBuilder.DropTable(
                name: "XMR_RECEIVE_ADDRESSES");

            migrationBuilder.DropTable(
                name: "CHATS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
