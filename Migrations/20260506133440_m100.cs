using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticaHospitalaria_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CamasDisponibles",
                table: "Camas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Camas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CamasDisponibles",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Camas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CamasDisponibles",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Camas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CamasDisponibles",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Camas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CamasDisponibles",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Camas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CamasDisponibles",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CamasDisponibles",
                table: "Camas");
        }
    }
}
