using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Migrations
{
    /// <inheritdoc />
    public partial class createInvestmentUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LowestCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerMeter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalUnitValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaintenancePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaintenanceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentUnits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentUnits");
        }
    }
}
