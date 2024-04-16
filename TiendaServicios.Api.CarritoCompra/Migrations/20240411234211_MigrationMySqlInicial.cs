using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationMySqlInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CarSession",
                columns: table => new
                {
                    CarSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSession", x => x.CarSessionId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CarSessionDetail",
                columns: table => new
                {
                    CarSessionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SelectedProduct = table.Column<string>(type: "longtext", nullable: false),
                    CarSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSessionDetail", x => x.CarSessionDetailId);
                    table.ForeignKey(
                        name: "FK_CarSessionDetail_CarSession_CarSessionId",
                        column: x => x.CarSessionId,
                        principalTable: "CarSession",
                        principalColumn: "CarSessionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CarSessionDetail_CarSessionId",
                table: "CarSessionDetail",
                column: "CarSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarSessionDetail");

            migrationBuilder.DropTable(
                name: "CarSession");
        }
    }
}
