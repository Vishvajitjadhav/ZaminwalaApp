using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectZApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedBy = table.Column<int>(type: "int", nullable: false),
                    PostType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    PlotNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoadNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasePricePerSqft = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarpetArea = table.Column<double>(type: "float", nullable: false),
                    BuiltUpArea = table.Column<double>(type: "float", nullable: false),
                    SuperBuiltUpArea = table.Column<double>(type: "float", nullable: false),
                    PropertyAge = table.Column<int>(type: "int", nullable: false),
                    ConstructionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Furnishing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNo = table.Column<int>(type: "int", nullable: false),
                    TotalFloors = table.Column<int>(type: "int", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Balconies = table.Column<int>(type: "int", nullable: false),
                    Halls = table.Column<int>(type: "int", nullable: false),
                    RERAStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PossessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoogleMapEmbedLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoostedListing = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
