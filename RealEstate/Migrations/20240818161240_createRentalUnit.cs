using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Migrations
{
    /// <inheritdoc />
    public partial class createRentalUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LowestCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitContents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RenterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RenterCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalUnits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalUnits");
        }
    }
}
