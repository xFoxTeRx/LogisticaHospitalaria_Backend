using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticaHospitalaria_Backend.Migrations
{
    /// <inheritdoc />
    public partial class P1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposSolicitud",
                columns: table => new
                {
                    TipoSolicitudId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSolicitud", x => x.TipoSolicitudId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false),
                    ReferenciaRRHH = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartamentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebhookSuscriptores",
                columns: table => new
                {
                    WebhookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreSistema = table.Column<string>(type: "text", nullable: false),
                    UrlCallback = table.Column<string>(type: "text", nullable: false),
                    SecretoFirma = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartamentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebhookSuscriptores", x => x.WebhookId);
                    table.ForeignKey(
                        name: "FK_WebhookSuscriptores_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposDepartamento",
                columns: table => new
                {
                    TipoDepartamentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoSolicitudId = table.Column<int>(type: "integer", nullable: false),
                    DepartamentoDuenoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDepartamento", x => x.TipoDepartamentoId);
                    table.ForeignKey(
                        name: "FK_TiposDepartamento_Departamentos_DepartamentoDuenoId",
                        column: x => x.DepartamentoDuenoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposDepartamento_TiposSolicitud_TipoSolicitudId",
                        column: x => x.TipoSolicitudId,
                        principalTable: "TiposSolicitud",
                        principalColumn: "TipoSolicitudId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    SolicitudId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Detalle = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Prioridad = table.Column<string>(type: "text", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: true),
                    FechaSolicitud = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaAceptacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEntrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    DepartamentoId = table.Column<int>(type: "integer", nullable: false),
                    TipoSolicitudId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioResponsableId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.SolicitudId);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitudes_TiposSolicitud_TipoSolicitudId",
                        column: x => x.TipoSolicitudId,
                        principalTable: "TiposSolicitud",
                        principalColumn: "TipoSolicitudId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Usuarios_UsuarioResponsableId",
                        column: x => x.UsuarioResponsableId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistorialSolicitudes",
                columns: table => new
                {
                    HistorialId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaCambio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstadoAnterior = table.Column<string>(type: "text", nullable: false),
                    EstadoNuevo = table.Column<string>(type: "text", nullable: false),
                    Observacion = table.Column<string>(type: "text", nullable: true),
                    SolicitudId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialSolicitudes", x => x.HistorialId);
                    table.ForeignKey(
                        name: "FK_HistorialSolicitudes_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitudes",
                        principalColumn: "SolicitudId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialSolicitudes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Activo", "Descripcion", "Nombre", "PublicId" },
                values: new object[,]
                {
                    { 1, true, null, "Gestión de Pacientes", new Guid("29bed892-6fc5-40e8-926c-ad7d9fdef6e5") },
                    { 2, true, null, "Emergencias y Triaje", new Guid("cfea66d0-c03c-41c1-8d71-61d382b6a358") },
                    { 3, true, null, "Consultas Externas", new Guid("01b9f986-4b4b-486f-815f-ad1b6e88c103") },
                    { 4, true, null, "Hospitalización", new Guid("e6d56236-348b-45de-a6f6-2bae26b38c20") },
                    { 5, true, null, "Cuidados Críticos", new Guid("9b7b593e-e592-4bcd-a624-c3894992a62f") },
                    { 6, true, null, "Gestión Quirúrgica", new Guid("0168f5cf-b36e-4316-87a7-ffcd66f4d868") },
                    { 7, true, null, "Especialidades Médicas", new Guid("361546a3-df8d-4f98-bc4d-fd07bf281b5e") },
                    { 8, true, null, "Diagnóstico Clínico", new Guid("1345d33f-3b5f-4f6e-8b10-5a58740b0a83") },
                    { 9, true, null, "Diagnóstico por Imágenes", new Guid("7b906583-22da-4462-9b89-8f415abdf6a8") },
                    { 10, true, null, "Farmacia Hospitalaria", new Guid("ec4f7443-15c7-40d9-87dd-23721c6e4353") },
                    { 11, true, null, "Terapias y Rehabilitación", new Guid("2ac07d0b-0e26-4e43-9ec3-8372b6df0cbb") },
                    { 12, true, null, "Maternidad y Neonatología", new Guid("3edcda48-55b1-4bd3-9bfc-1ef52e17ea86") },
                    { 13, true, null, "Gestión de Enfermería", new Guid("f550de45-a01a-4634-862c-6d7fb1f87a1d") },
                    { 14, true, null, "Gestión de Turnos y Citas", new Guid("686f43f3-cc15-4695-986a-397541315139") },
                    { 15, true, null, "Facturación y Seguros", new Guid("abba0eff-b7d2-4ba9-aef9-6b9cac775678") },
                    { 16, true, null, "Recursos Humanos", new Guid("741772c1-f2d2-466f-af13-ff0f2dea7df5") },
                    { 17, true, null, "Gestión Financiera", new Guid("bbeae720-09a3-4fb5-83ae-319139974d33") },
                    { 18, true, null, "Compras y Abastecimiento", new Guid("df17a08a-f5bd-44a5-b6a2-c78e24cdd794") },
                    { 19, true, null, "Gestión de Inventarios", new Guid("c9b09bd6-5431-41b0-b17d-6356f72c217e") },
                    { 20, true, null, "Mantenimiento y Activos", new Guid("d8466baa-7b84-49cc-8f78-90811988a644") },
                    { 21, true, null, "Soporte Técnico TI", new Guid("c2fc2f71-3c4b-4b23-9a81-2207a950fb4d") },
                    { 22, true, null, "Gestión de Calidad", new Guid("784ea619-b33a-41c8-94b9-093f990b53a2") },
                    { 23, true, null, "Bioseguridad y Control Sanitario", new Guid("66cd33db-b676-45bc-ba69-2fe50fe74c84") },
                    { 24, true, null, "Investigación Clínica", new Guid("955e792c-4445-48ed-9695-1fef8c48a944") },
                    { 25, true, null, "Docencia y Capacitación", new Guid("7273b434-f8e2-4b3f-b682-6d9d5d452b83") },
                    { 26, true, null, "Gestión Legal", new Guid("a84378a5-a23c-48cd-b967-634de18db853") },
                    { 27, true, null, "Atención al Paciente", new Guid("f2983a41-7250-49a3-8895-be00b61675f4") },
                    { 28, true, null, "Telemedicina", new Guid("71e61e91-7358-421b-a227-c6da6b539173") },
                    { 29, true, null, "Analítica y Reportes BI", new Guid("7d4555f3-ec29-4214-9744-d609f0b646fe") },
                    { 30, true, null, "Seguridad y Accesos", new Guid("1daba0d3-8ea4-46c3-bec3-d85eff214960") },
                    { 31, true, null, "Interoperabilidad e Integración", new Guid("44930908-5eec-4bac-8031-60e08447c478") },
                    { 32, true, null, "Gestión Documental", new Guid("96007c66-6703-4e40-a9c0-5175a6a619bf") },
                    { 33, true, null, "Logística Hospitalaria", new Guid("b6815f6e-641e-41ef-a67b-f606802a1048") },
                    { 34, true, null, "Gestión de Ambulancias", new Guid("ca718010-5db1-44ba-a4c9-3fe76fb20494") },
                    { 35, true, null, "Control Epidemiológico", new Guid("312dc45d-2c09-4a56-8c48-09a8ae06bece") },
                    { 36, true, null, "Psicología", new Guid("2e1aa3ec-9dd2-4e8e-999f-fc2036419a97") }
                });

            migrationBuilder.InsertData(
                table: "TiposSolicitud",
                columns: new[] { "TipoSolicitudId", "Activo", "Categoria", "Nombre", "PublicId" },
                values: new object[,]
                {
                    { 1, true, "Insumo", "Insumos Médicos", new Guid("6bfbf1dd-9bf7-4935-a713-21ee10b8ea09") },
                    { 2, true, "Insumo", "Medicamentos", new Guid("40062c3e-7a0a-485a-a93c-5c596440581e") },
                    { 3, true, "Equipo", "Equipamiento", new Guid("3a42082d-e46f-4d46-afbc-5360420ad49b") },
                    { 4, true, "Servicio", "Mantenimiento", new Guid("7af6b2b4-97d7-4964-ba65-543ee0d07df7") },
                    { 5, true, "Traslado", "Traslado de Materiales", new Guid("dabc5ff9-d4f6-4c4e-9ee7-f2374a2d606e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialSolicitudes_SolicitudId",
                table: "HistorialSolicitudes",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialSolicitudes_UsuarioId",
                table: "HistorialSolicitudes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_DepartamentoId",
                table: "Solicitudes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_TipoSolicitudId",
                table: "Solicitudes",
                column: "TipoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_UsuarioId",
                table: "Solicitudes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_UsuarioResponsableId",
                table: "Solicitudes",
                column: "UsuarioResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDepartamento_DepartamentoDuenoId",
                table: "TiposDepartamento",
                column: "DepartamentoDuenoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDepartamento_TipoSolicitudId",
                table: "TiposDepartamento",
                column: "TipoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoId",
                table: "Usuarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_WebhookSuscriptores_DepartamentoId",
                table: "WebhookSuscriptores",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialSolicitudes");

            migrationBuilder.DropTable(
                name: "TiposDepartamento");

            migrationBuilder.DropTable(
                name: "WebhookSuscriptores");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "TiposSolicitud");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
