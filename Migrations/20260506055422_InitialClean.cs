using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticaHospitalaria_Backend.Migrations
{
    public partial class InitialClean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DepartamentoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "PedidoDetalles",
                newName: "CantidadSolicitada");

            migrationBuilder.Sql(@"UPDATE ""Usuarios"" SET ""Rol"" = '0' WHERE ""Rol"" = 'Administrador' OR ""Rol"" = 'Admin';");
            migrationBuilder.Sql(@"UPDATE ""Usuarios"" SET ""Rol"" = '1' WHERE ""Rol"" = 'Operador';");
            migrationBuilder.Sql(@"ALTER TABLE ""Usuarios"" ALTER COLUMN ""Rol"" TYPE integer USING ""Rol""::integer;");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemNombre",
                table: "PedidoDetalles",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ItemExternoId",
                table: "PedidoDetalles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"UPDATE ""PedidoAutomaticos"" SET ""Estado"" = '0' WHERE ""Estado"" = 'Generado';");
            migrationBuilder.Sql(@"UPDATE ""PedidoAutomaticos"" SET ""Estado"" = '1' WHERE ""Estado"" = 'Enviado';");
            migrationBuilder.Sql(@"UPDATE ""PedidoAutomaticos"" SET ""Estado"" = '2' WHERE ""Estado"" = 'Completado';");
            migrationBuilder.Sql(@"ALTER TABLE ""PedidoAutomaticos"" ALTER COLUMN ""Estado"" TYPE integer USING ""Estado""::integer;");

            migrationBuilder.AlterColumn<string>(
                name: "Ubicacion",
                table: "Departamentos",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemExternoId",
                table: "PedidoDetalles");

            migrationBuilder.RenameColumn(
                name: "CantidadSolicitada",
                table: "PedidoDetalles",
                newName: "Cantidad");

            migrationBuilder.AlterColumn<string>(
                name: "Rol",
                table: "Usuarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ItemNombre",
                table: "PedidoDetalles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "PedidoAutomaticos",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Ubicacion",
                table: "Departamentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoId",
                table: "Usuarios",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoId",
                table: "Usuarios",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}