using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_CapStone_Mentorship_Service.Data.Migrations
{
    public partial class _05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    FormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(nullable: true),
                    TypeofTutor = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TutorName = table.Column<string>(nullable: true),
                    IsApptoved = table.Column<bool>(nullable: false),
                    MentorId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.FormId);
                    table.ForeignKey(
                        name: "FK_Forms_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "MentorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d382da9-81bf-44ba-a57f-72b49ae3f221", "432b5a16-4a86-407c-8c20-0bc11f4f7ef4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5d96c0a-5738-4780-97a7-ebdbb119df4b", "d76a9c93-3a27-4190-9256-9d8ecbdaab37", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e615eed-a2ac-43c0-830b-a1778219de54", "cb98cd5d-6746-447d-a68f-8125209625f4", "Mentor", "MENTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_MentorId",
                table: "Forms",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_StudentId",
                table: "Forms",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d382da9-81bf-44ba-a57f-72b49ae3f221");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e615eed-a2ac-43c0-830b-a1778219de54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5d96c0a-5738-4780-97a7-ebdbb119df4b");

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
        }
    }
}
