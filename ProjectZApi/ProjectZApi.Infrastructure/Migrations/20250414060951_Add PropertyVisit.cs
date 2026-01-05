using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectZApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    VisitorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyVisits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyVisits");
        }
    }
}
