using Microsoft.EntityFrameworkCore.Migrations;

namespace MasAcademyLab.Data.Migrations
{
    public partial class TrainingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 1,
                column: "TrainingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 2,
                column: "TrainingId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 1,
                column: "TrainingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 2,
                column: "TrainingId",
                value: null);
        }
    }
}
