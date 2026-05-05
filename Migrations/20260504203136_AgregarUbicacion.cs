using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticaHospitalaria_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AgregarUbicacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "Departamentos",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 1,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("487a416b-9f9a-4b7c-a211-76cfb343cd5d"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 2,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("7d99d970-60fa-4051-966c-4f964d577a59"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 3,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("eccd9208-db34-4ee7-8ae3-a32b7129decf"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 4,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("afc54b99-a6e1-4457-8a38-a746e1d87a5b"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 5,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("c42b4187-5bfd-4e06-b4e7-efec715644ea"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 6,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("da70aa48-05f9-4552-b057-96a1f4a69cf8"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 7,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("ca421660-185e-4480-9a71-6f894c20e67b"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 8,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("aa7b1c1c-e46e-48fc-b981-c29aef512075"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 9,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("c9329dcf-69bf-4b41-bdb9-a489941d2fe2"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 10,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("893b9b4e-9e13-4a82-9d75-e788a895757b"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 11,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("e97c03f0-c79b-431e-a1ad-3989aa6b4bf6"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 12,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("1d65283c-5b7a-4cef-8ceb-18a5b36c337a"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 13,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("7879b33c-d4c4-44b3-8d68-01f64d9e3842"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 14,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("26c5b525-0522-45c0-832c-c98dd2f680f1"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 15,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("e88bb420-a646-4e81-a304-d07541ca8cdd"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 16,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("fb5056bf-a672-47d1-a1c7-bf34a3cc6fef"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 17,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("dc9be65a-a28e-4911-bd8a-6e7681ffac8a"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 18,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("ec3b4a66-2943-4c84-a517-fd5653979528"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 19,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("ebebb9fc-e04c-45ae-8816-7e3063102b8c"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 20,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("5e295500-129e-4922-9615-17c99dc64b94"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 21,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("b273f8c1-b23c-471e-8301-a1ddb4ae4f38"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 22,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("e9ea1c03-07fd-4944-b92a-2f4f5ba39ade"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 23,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("8c2c8881-d2a5-40e9-b93f-f5fbe575a5cb"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 24,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("8801fd2b-3318-4654-8a74-85b06a1c17b7"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 25,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("f4743716-02b6-4115-b479-178fac79ac8f"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 26,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("3ffb7e44-2a97-4f5f-ba82-bbd61106e072"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 27,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("660d34e6-5e22-4128-8bfc-e0e90c24bb59"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 28,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("d64ff014-7798-444f-acc8-5f36898f75ae"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 29,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("7d5b8d7b-77c7-48bb-8525-e0ed36efe5b2"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 30,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("6d1a088e-ae62-4b95-9795-77a3c92fd205"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 31,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("e404a7cf-b256-4a7a-a18f-26ace7201069"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 32,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("8492c3a9-1404-418a-bd4f-ee38ed1704cf"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 33,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("8c3efd66-64b2-4a73-8c6e-da296122475b"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 34,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("85750ed4-1c28-4dbb-b377-66fdac393f5b"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 35,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("0777b4e4-0fad-49a7-89c8-6a9cc22a1cc0"), null });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 36,
                columns: new[] { "PublicId", "Ubicacion" },
                values: new object[] { new Guid("5b5b341a-e4c0-4f1b-a5c1-ead9cbcf39be"), null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "Departamentos");

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
                column: "PublicId",
                value: new Guid("9b8e491e-1466-42d3-a76c-f7517a4566d5"));

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

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 6,
                column: "PublicId",
                value: new Guid("98bd8a9f-b89b-4948-8d4b-95b993f91244"));

            migrationBuilder.UpdateData(
                table: "TiposSolicitud",
                keyColumn: "TipoSolicitudId",
                keyValue: 7,
                column: "PublicId",
                value: new Guid("9a37c4c6-1a4a-4a6a-bd20-38f92d85af17"));
        }
    }
}
