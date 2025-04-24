using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicineFormFrequencyAndStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Medicines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Medicines",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Medicines");
        }
    }
}
