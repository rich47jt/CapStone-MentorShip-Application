using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_CapStone_Mentorship_Service.Data.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Admins_AdminId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Mentors_MentorId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Junctions_Activities_ActivityId",
                table: "Junctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Junctions_Mentors_MentorId",
                table: "Junctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Junctions_Reviews_ReviewId",
                table: "Junctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Junctions",
                table: "Junctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53d42d99-7a48-4b44-89dd-6f638914ced8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59d47fb8-0de4-482e-9c1a-265c6ac41613");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e04abb16-722f-470d-a54f-27b14c7e2a5a");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Junctions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "EducationalBackRound",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Reviews",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "MentorName",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MentorId",
                table: "Mentors",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Lessons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudnetMentorId",
                table: "Junctions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Applications",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "EducationalBackGround",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Admins",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ActivityFormId",
                table: "Activities",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors",
                column: "MentorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Junctions",
                table: "Junctions",
                column: "StudnetMentorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "ActivityFormId");

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
                name: "FK_Applications_Admins_AdminId",
                table: "Applications",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Mentors_MentorId",
                table: "Applications",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "MentorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junctions_Activities_ActivityId",
                table: "Junctions",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityFormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junctions_Mentors_MentorId",
                table: "Junctions",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "MentorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junctions_Reviews_ReviewId",
                table: "Junctions",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Admins_AdminId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Mentors_MentorId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Junctions_Activities_ActivityId",
                table: "Junctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Junctions_Mentors_MentorId",
                table: "Junctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Junctions_Reviews_ReviewId",
                table: "Junctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Junctions",
                table: "Junctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

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
                name: "ReviewId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "MentorName",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "StudnetMentorId",
                table: "Junctions");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "EducationalBackGround",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "ActivityFormId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Reviews",
                newName: "rating");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Mentors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Junctions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "EducationalBackRound",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MentorId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Junctions",
                table: "Junctions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53d42d99-7a48-4b44-89dd-6f638914ced8", "76e7e1e4-cfa8-408f-8b14-c80d29bcc141", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e04abb16-722f-470d-a54f-27b14c7e2a5a", "a246229f-efdf-4f71-a25b-72a0e4298300", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59d47fb8-0de4-482e-9c1a-265c6ac41613", "a5368d2c-6db8-4a9b-9de5-b403e4c0adc2", "Mentor", "MENTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Admins_AdminId",
                table: "Applications",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Mentors_MentorId",
                table: "Applications",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junctions_Activities_ActivityId",
                table: "Junctions",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junctions_Mentors_MentorId",
                table: "Junctions",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junctions_Reviews_ReviewId",
                table: "Junctions",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
