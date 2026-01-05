using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectZApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LocationIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LocationId",
                table: "Properties",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Locations_LocationId",
                table: "Properties",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Locations_LocationId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Properties_LocationId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Properties");
        }
    }
}
