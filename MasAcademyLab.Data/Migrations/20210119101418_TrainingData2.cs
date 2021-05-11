using Microsoft.EntityFrameworkCore.Migrations;

namespace MasAcademyLab.Data.Migrations
{
    public partial class TrainingData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "TrainingId",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "ATL2018", "Atlanta Code Training" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "TrainingId",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { null, "Atlanta Code Camp" });
        }
    }
}
