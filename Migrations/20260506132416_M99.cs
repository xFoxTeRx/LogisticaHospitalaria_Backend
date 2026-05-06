using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticaHospitalaria_Backend.Migrations
{
    /// <inheritdoc />
    public partial class M99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    CantidadCamas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Camas",
                columns: new[] { "Id", "CantidadCamas", "Departamento" },
                values: new object[,]
                {
                    { 1, 20, "Emergencias" },
                    { 2, 15, "Pediatría" },
                    { 3, 10, "UCI" },
                    { 4, 25, "Cirugía" },
                    { 5, 18, "Maternidad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camas");
        }
    }
}
