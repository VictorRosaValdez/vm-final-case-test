using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DOTNET_Final_Case_BackEnd.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Description", "Industry", "Link", "Photo", "Progress", "Screen", "Theme", "Title" },
                values: new object[,]
                {
                    { 1, ".NET is an open source platform", null, null, null, null, null, "IT", "The world of .NET" },
                    { 2, "Java is an open source programming language", null, null, null, null, null, "IT", "Java" },
                    { 3, "C# an open source programming language", null, null, null, null, null, "IT", "C#" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "SkillId", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Java" },
                    { 3, "html" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Description", "Email", "Hidden", "Name", "Password", "Portfolio" },
                values: new object[,]
                {
                    { 1, null, "leroy.finalcase@hotmail.com", false, "Leroy", "admin", null },
                    { 2, null, "dorine.finalcase@hotmail.com", false, "Dorine", "admin", null },
                    { 3, null, "pim.finalcase@hotmail.com", false, "Pim", "admin", null },
                    { 4, null, "victor.finalcase@hotmail.com", false, "Victor", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "MessageId", "Description", "ProjectId", "UserId" },
                values: new object[,]
                {
                    { 1, "Hello World", 1, 2 },
                    { 2, "Hiiiiiiiii", 1, 1 },
                    { 3, "It is finished", 2, 3 },
                    { 4, "Well Done!", 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProjectUser",
                columns: new[] { "ProjectId", "UserId", "IsOwner" },
                values: new object[,]
                {
                    { 1, 2, false },
                    { 2, 1, false }
                });

            migrationBuilder.InsertData(
                table: "SkillProject",
                columns: new[] { "ProjectId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "SkillsUser",
                columns: new[] { "SkillId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 4 },
                    { 3, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectUser",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectUser",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SkillProject",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SkillProject",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "SkillsUser",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SkillsUser",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "SkillsUser",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "SkillsUser",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "SkillId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "SkillId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "SkillId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4);
        }
    }
}
