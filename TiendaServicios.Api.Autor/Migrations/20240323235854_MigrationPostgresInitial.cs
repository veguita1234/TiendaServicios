using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TiendaServicios.Api.Autor.Migrations
{
    /// <inheritdoc />
    public partial class MigrationPostgresInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorBookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateBirth =table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AuthorBookGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => x.AuthorBookId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicLevel",
                columns: table => new
                {
                    AcademicLevelId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AcademicCenter = table.Column<string>(type: "text", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AuthorBookId = table.Column<int>(type: "integer", nullable: false),
                    AcademicLevelGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicLevel", x => x.AcademicLevelId);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_AuthorBook_AuthorBookId",
                        column: x => x.AuthorBookId,
                        principalTable: "AuthorBook",
                        principalColumn: "AuthorBookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_AuthorBookId",
                table: "AcademicLevel",
                column: "AuthorBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicLevel");

            migrationBuilder.DropTable(
                name: "AuthorBook");
        }
    }
}
