using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectZApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyStatus",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "PropertyStatus",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
