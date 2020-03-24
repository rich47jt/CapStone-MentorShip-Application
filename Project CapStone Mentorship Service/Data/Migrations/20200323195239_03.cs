using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_CapStone_Mentorship_Service.Data.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Junctions_Lessons_LessonId",
                table: "Junctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eacb533-8127-4ef0-b5a2-a3463fd7dcd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9917bb52-9269-4ab3-b492-401d2c510f0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb4af509-981a-428a-b817-cad173b2c4c9");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Lessons",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "LessonId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8762f0bd-3e30-411e-bb62-9d14ac392bb5", "2c0301e4-64eb-484f-86c8-82132aad495d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "991d3467-5d5f-4598-812a-6bcce263e74d", "73b6b447-2e50-4622-82d1-64bf5286f24f", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6e2fc79-99b4-4d3b-82bb-6b5158f4d4d4", "6aa49108-0214-4b29-9782-07c35efb7b82", "Mentor", "MENTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Junctions_Lessons_LessonId",
                table: "Junctions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Junctions_Lessons_LessonId",
                table: "Junctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8762f0bd-3e30-411e-bb62-9d14ac392bb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "991d3467-5d5f-4598-812a-6bcce263e74d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6e2fc79-99b4-4d3b-82bb-6b5158f4d4d4");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb4af509-981a-428a-b817-cad173b2c4c9", "bbb52510-ade1-41ed-a111-623feb9a13ae", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9917bb52-9269-4ab3-b492-401d2c510f0b", "97df5ec1-a81d-4548-b683-5b34de9cfe2d", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0eacb533-8127-4ef0-b5a2-a3463fd7dcd6", "8ec37b12-7032-401d-8a4b-08dc5c66afba", "Mentor", "MENTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Junctions_Lessons_LessonId",
                table: "Junctions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
