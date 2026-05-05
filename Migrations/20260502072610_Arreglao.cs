using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticaHospitalaria_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Arreglao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Departamentos_DepartamentoId",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Solicitudes");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoDestinoId",
                table: "Solicitudes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRequerida",
                table: "Solicitudes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetallesSolicitud",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemNombre = table.Column<string>(type: "text", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: true),
                    Unidad = table.Column<string>(type: "text", nullable: true),
                    Observacion = table.Column<string>(type: "text", nullable: true),
                    SolicitudId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesSolicitud", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_DetallesSolicitud_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitudes",
                        principalColumn: "SolicitudId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 1,
                column: "PublicId",
                value: new Guid("1bd3be45-83ee-411c-b3b3-7517baded477"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 2,
                column: "PublicId",
                value: new Guid("45770547-3162-4606-a0ca-8a6c8283cfd8"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 3,
                column: "PublicId",
                value: new Guid("709124f5-bd71-4312-a350-c06dd44736db"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 4,
                column: "PublicId",
                value: new Guid("2c055350-4870-4e29-85a1-5a866db6b256"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 5,
                column: "PublicId",
                value: new Guid("0f1640b6-1378-4016-b71f-f3688a19f784"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 6,
                column: "PublicId",
                value: new Guid("3e58d852-2dbd-4e82-8d1a-8d230713b84f"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 7,
                column: "PublicId",
                value: new Guid("bed59ed8-4119-41a8-8d12-3dc91c05ed06"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 8,
                column: "PublicId",
                value: new Guid("9e117609-a717-4506-8b0a-62c19942ecbd"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 9,
                column: "PublicId",
                value: new Guid("7913491d-8870-419e-a934-68663440efdb"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 10,
                column: "PublicId",
                value: new Guid("936f1216-032d-4cb6-90fc-592eb1421736"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 11,
                column: "PublicId",
                value: new Guid("92accf79-1da6-468a-a538-c4b9062fbe9a"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 12,
                column: "PublicId",
                value: new Guid("05ca69d3-35ac-4351-b073-9952126f0d3b"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 13,
                column: "PublicId",
                value: new Guid("85594cba-d44b-4c44-9512-f9b893aa32f0"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 14,
                column: "PublicId",
                value: new Guid("1093333e-4d22-4fc6-8852-51b403555515"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 15,
                column: "PublicId",
                value: new Guid("c6554b4d-9d69-4f22-946e-d3cb041e21b2"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 16,
                column: "PublicId",
                value: new Guid("155d6c2b-8e0d-45a6-87b3-2a7495c2bd90"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 17,
                column: "PublicId",
                value: new Guid("cd142794-7e8c-4fa6-b356-a9a071fbec7e"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 18,
                column: "PublicId",
                value: new Guid("e9c610eb-93a1-4d34-b8bd-9f4e199c9fc4"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 19,
                column: "PublicId",
                value: new Guid("5cbe24c3-07d0-4407-9fd4-514b0abc07c8"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 20,
                column: "PublicId",
                value: new Guid("8821bba3-5f94-4936-ac50-d436acc2b11c"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 21,
                column: "PublicId",
                value: new Guid("02c9b0af-bf7a-4842-8fee-40a8a03cb520"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 22,
                column: "PublicId",
                value: new Guid("1f945fac-42dc-4a6b-b3a8-33f3e3447d7d"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 23,
                column: "PublicId",
                value: new Guid("0fffa1e1-3509-46a1-9e4e-f7aa61dc050c"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 24,
                column: "PublicId",
                value: new Guid("2d3c3989-079d-4f61-83a5-0867edc94d14"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 25,
                column: "PublicId",
                value: new Guid("30b44dda-d52c-4ade-9d62-8696a280215c"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 26,
                column: "PublicId",
                value: new Guid("92363890-3875-4574-a627-2b07f4e333eb"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 27,
                column: "PublicId",
                value: new Guid("9fdccbb8-f4e9-4a06-9026-58ee19aa9f8f"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 28,
                column: "PublicId",
                value: new Guid("e482105e-54f0-4cdb-bb23-ffa68d9f67a4"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 29,
                column: "PublicId",
                value: new Guid("eef73ae0-0522-40ca-b58e-3ad1b74a470e"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 30,
                column: "PublicId",
                value: new Guid("bcf08965-db0b-4ba0-89aa-886691e73829"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 31,
                column: "PublicId",
                value: new Guid("d9c6a554-3b99-4f75-a1f2-c729875571ef"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 32,
                column: "PublicId",
                value: new Guid("83f4df86-8135-4d0b-b2c3-aa0c554aee65"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 33,
                column: "PublicId",
                value: new Guid("3b8c317f-6c3e-4a65-b419-89635218b363"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 34,
                column: "PublicId",
                value: new Guid("112101e0-feb6-498a-8202-21e4953a4ee3"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 35,
                column: "PublicId",
                value: new Guid("3c035a0c-9f6d-44f8-a6c9-88a43092630f"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 36,
                column: "PublicId",
                value: new Guid("3579a608-bb22-4560-9b10-760e733e9944"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 1,
                column: "PublicId",
                value: new Guid("c8feb700-1ef2-4a63-9485-8403c8a9bab9"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 2,
                column: "PublicId",
                value: new Guid("ae9cba63-501f-4560-9d18-2c9ff2950d1a"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 3,
                columns: new[] { "Categoria", "PublicId" },
                values: new object[] { "Insumo", new Guid("9b8e491e-1466-42d3-a76c-f7517a4566d5") });

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 4,
                column: "PublicId",
                value: new Guid("d88f6332-32e6-4aaa-8b90-77501c57a337"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 5,
                column: "PublicId",
                value: new Guid("7100cf8c-ac55-41b0-b501-009f7358b08a"));

            migrationBuilder.InsertData(
                table: "TiposSolicitud",
                columns: new[] { "TipoSolicitudId", "Activo", "Categoria", "Nombre", "PublicId" },
                values: new object[,]
                {
                    { 6, true, "Servicio", "Reunión", new Guid("98bd8a9f-b89b-4948-8d4b-95b993f91244") },
                    { 7, true, "Servicio", "Permiso", new Guid("9a37c4c6-1a4a-4a6a-bd20-38f92d85af17") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_DepartamentoDestinoId",
                table: "Solicitudes",
                column: "DepartamentoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesSolicitud_SolicitudId",
                table: "DetallesSolicitud",
                column: "SolicitudId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Departamentos_DepartamentoDestinoId",
                table: "Solicitudes",
                column: "DepartamentoDestinoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Departamentos_DepartamentoId",
                table: "Solicitudes",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Departamentos_DepartamentoDestinoId",
                table: "Solicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Departamentos_DepartamentoId",
                table: "Solicitudes");

            migrationBuilder.DropTable(
                name: "DetallesSolicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitudes_DepartamentoDestinoId",
                table: "Solicitudes");

            migrationBuilder.DeleteData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "DepartamentoDestinoId",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "FechaRequerida",
                table: "Solicitudes");

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Solicitudes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 1,
                column: "PublicId",
                value: new Guid("29bed892-6fc5-40e8-926c-ad7d9fdef6e5"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 2,
                column: "PublicId",
                value: new Guid("cfea66d0-c03c-41c1-8d71-61d382b6a358"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 3,
                column: "PublicId",
                value: new Guid("01b9f986-4b4b-486f-815f-ad1b6e88c103"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 4,
                column: "PublicId",
                value: new Guid("e6d56236-348b-45de-a6f6-2bae26b38c20"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 5,
                column: "PublicId",
                value: new Guid("9b7b593e-e592-4bcd-a624-c3894992a62f"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 6,
                column: "PublicId",
                value: new Guid("0168f5cf-b36e-4316-87a7-ffcd66f4d868"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 7,
                column: "PublicId",
                value: new Guid("361546a3-df8d-4f98-bc4d-fd07bf281b5e"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 8,
                column: "PublicId",
                value: new Guid("1345d33f-3b5f-4f6e-8b10-5a58740b0a83"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 9,
                column: "PublicId",
                value: new Guid("7b906583-22da-4462-9b89-8f415abdf6a8"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 10,
                column: "PublicId",
                value: new Guid("ec4f7443-15c7-40d9-87dd-23721c6e4353"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 11,
                column: "PublicId",
                value: new Guid("2ac07d0b-0e26-4e43-9ec3-8372b6df0cbb"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 12,
                column: "PublicId",
                value: new Guid("3edcda48-55b1-4bd3-9bfc-1ef52e17ea86"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 13,
                column: "PublicId",
                value: new Guid("f550de45-a01a-4634-862c-6d7fb1f87a1d"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 14,
                column: "PublicId",
                value: new Guid("686f43f3-cc15-4695-986a-397541315139"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 15,
                column: "PublicId",
                value: new Guid("abba0eff-b7d2-4ba9-aef9-6b9cac775678"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 16,
                column: "PublicId",
                value: new Guid("741772c1-f2d2-466f-af13-ff0f2dea7df5"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 17,
                column: "PublicId",
                value: new Guid("bbeae720-09a3-4fb5-83ae-319139974d33"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 18,
                column: "PublicId",
                value: new Guid("df17a08a-f5bd-44a5-b6a2-c78e24cdd794"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 19,
                column: "PublicId",
                value: new Guid("c9b09bd6-5431-41b0-b17d-6356f72c217e"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 20,
                column: "PublicId",
                value: new Guid("d8466baa-7b84-49cc-8f78-90811988a644"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 21,
                column: "PublicId",
                value: new Guid("c2fc2f71-3c4b-4b23-9a81-2207a950fb4d"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 22,
                column: "PublicId",
                value: new Guid("784ea619-b33a-41c8-94b9-093f990b53a2"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 23,
                column: "PublicId",
                value: new Guid("66cd33db-b676-45bc-ba69-2fe50fe74c84"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 24,
                column: "PublicId",
                value: new Guid("955e792c-4445-48ed-9695-1fef8c48a944"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 25,
                column: "PublicId",
                value: new Guid("7273b434-f8e2-4b3f-b682-6d9d5d452b83"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 26,
                column: "PublicId",
                value: new Guid("a84378a5-a23c-48cd-b967-634de18db853"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 27,
                column: "PublicId",
                value: new Guid("f2983a41-7250-49a3-8895-be00b61675f4"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 28,
                column: "PublicId",
                value: new Guid("71e61e91-7358-421b-a227-c6da6b539173"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 29,
                column: "PublicId",
                value: new Guid("7d4555f3-ec29-4214-9744-d609f0b646fe"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 30,
                column: "PublicId",
                value: new Guid("1daba0d3-8ea4-46c3-bec3-d85eff214960"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 31,
                column: "PublicId",
                value: new Guid("44930908-5eec-4bac-8031-60e08447c478"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 32,
                column: "PublicId",
                value: new Guid("96007c66-6703-4e40-a9c0-5175a6a619bf"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 33,
                column: "PublicId",
                value: new Guid("b6815f6e-641e-41ef-a67b-f606802a1048"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 34,
                column: "PublicId",
                value: new Guid("ca718010-5db1-44ba-a4c9-3fe76fb20494"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 35,
                column: "PublicId",
                value: new Guid("312dc45d-2c09-4a56-8c48-09a8ae06bece"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 36,
                column: "PublicId",
                value: new Guid("2e1aa3ec-9dd2-4e8e-999f-fc2036419a97"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 1,
                column: "PublicId",
                value: new Guid("6bfbf1dd-9bf7-4935-a713-21ee10b8ea09"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 2,
                column: "PublicId",
                value: new Guid("40062c3e-7a0a-485a-a93c-5c596440581e"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 3,
                columns: new[] { "Categoria", "PublicId" },
                values: new object[] { "Equipo", new Guid("3a42082d-e46f-4d46-afbc-5360420ad49b") });

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 4,
                column: "PublicId",
                value: new Guid("7af6b2b4-97d7-4964-ba65-543ee0d07df7"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 5,
                column: "PublicId",
                value: new Guid("dabc5ff9-d4f6-4c4e-9ee7-f2374a2d606e"));

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Departamentos_DepartamentoId",
                table: "Solicitudes",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
