using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectZApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class KYCStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KYCFilePath",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KYCStatus",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KYCFilePath",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "KYCStatus",
                table: "Properties");
        }
    }
}
