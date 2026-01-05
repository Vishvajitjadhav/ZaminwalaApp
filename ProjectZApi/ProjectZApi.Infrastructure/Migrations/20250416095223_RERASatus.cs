using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectZApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RERASatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RERAStatus",
                table: "Properties",
                newName: "UploadReraFilePath");

            migrationBuilder.AddColumn<int>(
                name: "RStatus",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Properties",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SellerId",
                table: "Properties",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_SellerId",
                table: "Properties",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_SellerId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_SellerId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "RStatus",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "UploadReraFilePath",
                table: "Properties",
                newName: "RERAStatus");
        }
    }
}
