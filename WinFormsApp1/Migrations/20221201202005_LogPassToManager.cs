using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinFormsApp1.Migrations
{
    /// <inheritdoc />
    public partial class LogPassToManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENT",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Passport = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ClientName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    ClientSurname = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    ClientMiddleName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CLIENT__E67E1A04863F7055", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "MANAGER",
                columns: table => new
                {
                    ManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MPhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MSurname = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Login = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MMiddleName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MANAGER__3BA2AA81B25F7CAF", x => x.ManagerID);
                });

            migrationBuilder.CreateTable(
                name: "ROOM",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedQTY = table.Column<int>(type: "int", nullable: false),
                    FreeBedQTY = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROOM__328639197DFBF754", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "ZASELENIE",
                columns: table => new
                {
                    ZaselenieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    DataZasel = table.Column<DateTime>(type: "date", nullable: false),
                    DataVisel = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ZASELENI__3800D253729AD88B", x => x.ZaselenieID);
                    table.ForeignKey(
                        name: "FK__ZASELENIE__Clien__286302EC",
                        column: x => x.ClientID,
                        principalTable: "CLIENT",
                        principalColumn: "ClientID");
                    table.ForeignKey(
                        name: "FK__ZASELENIE__RoomI__29572725",
                        column: x => x.RoomID,
                        principalTable: "ROOM",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZASELENIE_ClientID",
                table: "ZASELENIE",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ZASELENIE_RoomID",
                table: "ZASELENIE",
                column: "RoomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MANAGER");

            migrationBuilder.DropTable(
                name: "ZASELENIE");

            migrationBuilder.DropTable(
                name: "CLIENT");

            migrationBuilder.DropTable(
                name: "ROOM");
        }
    }
}
