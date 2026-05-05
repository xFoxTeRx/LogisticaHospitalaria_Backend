using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticaHospitalaria_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCodigoDepartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Departamentos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 1,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("acc04347-f411-432b-b7e2-5784482a8f5d") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 2,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("55e84de0-4de1-49f8-9cb9-5e5fc3f4a419") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 3,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("6ead7d3a-8ad1-4fbb-be55-62bb2c7dd812") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 4,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("ec9aab9d-b89d-428b-8ad9-5d39aaef8982") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 5,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("7be3408a-b014-4dbe-bf4d-0e5a051ed37b") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 6,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("0f0e7a13-84f9-492f-8727-42dde8736f53") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 7,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("a350f35a-9990-4532-ab8d-b4ae3d8f3d4d") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 8,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("a23bde86-1aab-4fe7-803e-d21ebdc9cfa2") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 9,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("8965e0af-61f0-4095-9388-652e8a370d0e") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 10,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("b0d8f384-d257-400d-82af-047583d5fa54") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 11,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("3d7a7d53-11bd-4c98-a784-6c25b44fb7c0") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 12,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("85dc041c-d0ca-4e1f-9353-27da7035e88e") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 13,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("2ca45482-ed98-4120-9b44-c42d42498af7") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 14,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("9417c3e3-c6b9-421f-af13-fb901388df5f") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 15,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("d83cca99-9331-4e64-a9b0-9faaaaa78a05") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 16,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("69e3a98f-4fb8-4c52-a2f6-0c2ef4ddbb33") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 17,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("6c33ac9e-1975-446f-a762-f935d95a201b") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 18,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("c14e1cb1-b2c8-44d5-8c25-d84c47f31d41") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 19,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("4836422e-4b58-408c-81a1-1179d45a4347") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 20,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("f5522698-03b9-4c64-ac24-11ee0ec6911c") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 21,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("05835c9b-6803-41de-88c3-b13770a1cca9") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 22,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("ba830628-948e-4a29-808e-88bb28af7e05") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 23,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("0018a954-8d8e-47d4-b34f-9e75ff45cc69") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 24,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("d5860ade-7211-4c55-b358-eb985bd05cd9") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 25,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("0f42fe98-12a8-44a5-bbb9-ad9fe2f251fa") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 26,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("94d05067-0ce8-406a-ab5c-6601804005a2") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 27,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("76657e1f-3026-4193-8764-92cf83b8c787") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 28,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("3fd69305-9131-4a20-a905-ebed1296fea8") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 29,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("c0222063-314e-41f9-b0f6-d80f428fc200") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 30,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("6a32418b-baab-47bf-8ffa-cedaaa180533") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 31,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("99d881f4-3731-407a-80c6-2ea3320a558a") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 32,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("839ee6a8-9a4e-4c91-bd99-cccf17c13b23") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 33,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("2a100641-2617-4102-83fd-b2ffe9e726a9") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 34,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("6b569618-80f1-4a0f-8c69-4860c8830d77") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 35,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("078ebdb4-4202-491e-988b-1445d08bab52") });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 36,
                columns: new[] { "Codigo", "PublicId" },
                values: new object[] { "", new Guid("1d2a1583-80b1-4641-a32c-1a6ec687ff0d") });

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 1,
                column: "PublicId",
                value: new Guid("921138c7-2edc-4715-816c-681a491bb5b7"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 2,
                column: "PublicId",
                value: new Guid("c41a7cd5-37ec-4eb5-870c-69330d2420a5"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 3,
                column: "PublicId",
                value: new Guid("9b3656d6-2a27-4390-86ab-cb58f479978a"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 4,
                column: "PublicId",
                value: new Guid("f56a1192-e022-45a3-b511-be39ada6032b"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 5,
                column: "PublicId",
                value: new Guid("dfa5473c-fc48-4b51-96bf-4b0fb3385677"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 6,
                column: "PublicId",
                value: new Guid("461f8e7c-9925-4e21-a8ba-c563c4f8bbdb"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 7,
                column: "PublicId",
                value: new Guid("c6cde35e-f832-4b4e-b782-5dcd63ffb913"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Departamentos");

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 1,
                column: "PublicId",
                value: new Guid("487a416b-9f9a-4b7c-a211-76cfb343cd5d"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 2,
                column: "PublicId",
                value: new Guid("7d99d970-60fa-4051-966c-4f964d577a59"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 3,
                column: "PublicId",
                value: new Guid("eccd9208-db34-4ee7-8ae3-a32b7129decf"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 4,
                column: "PublicId",
                value: new Guid("afc54b99-a6e1-4457-8a38-a746e1d87a5b"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 5,
                column: "PublicId",
                value: new Guid("c42b4187-5bfd-4e06-b4e7-efec715644ea"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 6,
                column: "PublicId",
                value: new Guid("da70aa48-05f9-4552-b057-96a1f4a69cf8"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 7,
                column: "PublicId",
                value: new Guid("ca421660-185e-4480-9a71-6f894c20e67b"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 8,
                column: "PublicId",
                value: new Guid("aa7b1c1c-e46e-48fc-b981-c29aef512075"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 9,
                column: "PublicId",
                value: new Guid("c9329dcf-69bf-4b41-bdb9-a489941d2fe2"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 10,
                column: "PublicId",
                value: new Guid("893b9b4e-9e13-4a82-9d75-e788a895757b"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 11,
                column: "PublicId",
                value: new Guid("e97c03f0-c79b-431e-a1ad-3989aa6b4bf6"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 12,
                column: "PublicId",
                value: new Guid("1d65283c-5b7a-4cef-8ceb-18a5b36c337a"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 13,
                column: "PublicId",
                value: new Guid("7879b33c-d4c4-44b3-8d68-01f64d9e3842"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 14,
                column: "PublicId",
                value: new Guid("26c5b525-0522-45c0-832c-c98dd2f680f1"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 15,
                column: "PublicId",
                value: new Guid("e88bb420-a646-4e81-a304-d07541ca8cdd"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 16,
                column: "PublicId",
                value: new Guid("fb5056bf-a672-47d1-a1c7-bf34a3cc6fef"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 17,
                column: "PublicId",
                value: new Guid("dc9be65a-a28e-4911-bd8a-6e7681ffac8a"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 18,
                column: "PublicId",
                value: new Guid("ec3b4a66-2943-4c84-a517-fd5653979528"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 19,
                column: "PublicId",
                value: new Guid("ebebb9fc-e04c-45ae-8816-7e3063102b8c"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 20,
                column: "PublicId",
                value: new Guid("5e295500-129e-4922-9615-17c99dc64b94"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 21,
                column: "PublicId",
                value: new Guid("b273f8c1-b23c-471e-8301-a1ddb4ae4f38"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 22,
                column: "PublicId",
                value: new Guid("e9ea1c03-07fd-4944-b92a-2f4f5ba39ade"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 23,
                column: "PublicId",
                value: new Guid("8c2c8881-d2a5-40e9-b93f-f5fbe575a5cb"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 24,
                column: "PublicId",
                value: new Guid("8801fd2b-3318-4654-8a74-85b06a1c17b7"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 25,
                column: "PublicId",
                value: new Guid("f4743716-02b6-4115-b479-178fac79ac8f"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 26,
                column: "PublicId",
                value: new Guid("3ffb7e44-2a97-4f5f-ba82-bbd61106e072"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 27,
                column: "PublicId",
                value: new Guid("660d34e6-5e22-4128-8bfc-e0e90c24bb59"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 28,
                column: "PublicId",
                value: new Guid("d64ff014-7798-444f-acc8-5f36898f75ae"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 29,
                column: "PublicId",
                value: new Guid("7d5b8d7b-77c7-48bb-8525-e0ed36efe5b2"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 30,
                column: "PublicId",
                value: new Guid("6d1a088e-ae62-4b95-9795-77a3c92fd205"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 31,
                column: "PublicId",
                value: new Guid("e404a7cf-b256-4a7a-a18f-26ace7201069"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 32,
                column: "PublicId",
                value: new Guid("8492c3a9-1404-418a-bd4f-ee38ed1704cf"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 33,
                column: "PublicId",
                value: new Guid("8c3efd66-64b2-4a73-8c6e-da296122475b"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 34,
                column: "PublicId",
                value: new Guid("85750ed4-1c28-4dbb-b377-66fdac393f5b"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 35,
                column: "PublicId",
                value: new Guid("0777b4e4-0fad-49a7-89c8-6a9cc22a1cc0"));

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 36,
                column: "PublicId",
                value: new Guid("5b5b341a-e4c0-4f1b-a5c1-ead9cbcf39be"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 1,
                column: "PublicId",
                value: new Guid("da567cda-519f-4102-859c-0db7dcb9b2a9"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 2,
                column: "PublicId",
                value: new Guid("a63c5a26-1781-40ec-a0e7-f91aef07b088"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 3,
                column: "PublicId",
                value: new Guid("d0144e38-7303-495a-8c0a-bbc64a475075"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 4,
                column: "PublicId",
                value: new Guid("6c91a996-8053-4808-b021-469e422bd694"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 5,
                column: "PublicId",
                value: new Guid("3a6f0f4b-910b-4a04-bad4-99cc3505943f"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 6,
                column: "PublicId",
                value: new Guid("0080ce83-705f-4ae7-8322-c32f8ee705c9"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 7,
                column: "PublicId",
                value: new Guid("9bdf2954-6981-4573-b359-b756e9f2ecce"));
        }
    }
}
