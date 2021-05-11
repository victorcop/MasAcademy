using Microsoft.EntityFrameworkCore.Migrations;

namespace MasAcademyLab.Data.Migrations
{
    public partial class MasAcademySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "LocationId",
                keyValue: 1,
                columns: new[] { "Address1", "CityTown", "Country", "StateProvince", "VenueName" },
                values: new object[] { "Calle 5 #45-54", "Medellín, Colombia", "COL", "ME", "" });

            migrationBuilder.UpdateData(
                table: "Speakers",
                keyColumn: "SpeakerId",
                keyValue: 1,
                columns: new[] { "BlogUrl", "Company", "CompanyUrl", "FirstName", "GitHub", "LastName", "Twitter" },
                values: new object[] { "", "Mas Global Consulting", "https://masglobalconsulting.com/", "Victor", "https://github.com/victorcop", "Velasquez", "@victorcop55" });

            migrationBuilder.UpdateData(
                table: "Speakers",
                keyColumn: "SpeakerId",
                keyValue: 2,
                columns: new[] { "BlogUrl", "Company", "CompanyUrl", "FirstName", "GitHub", "LastName", "Twitter" },
                values: new object[] { "", "Mas Global Consulting", "https://masglobalconsulting.com/", "Francisco", "", "Gutierrez", "" });

            migrationBuilder.UpdateData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 1,
                columns: new[] { "Abstract", "Title" },
                values: new object[] { ".Net Core API in an hour.", ".Net Core API" });

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "TrainingId",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "MAS2021", "Mas Academy Code Training" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "LocationId",
                keyValue: 1,
                columns: new[] { "Address1", "CityTown", "Country", "StateProvince", "VenueName" },
                values: new object[] { "123 Main Street", "Atlanta", "USA", "GA", "Atlanta Convention Center" });

            migrationBuilder.UpdateData(
                table: "Speakers",
                keyColumn: "SpeakerId",
                keyValue: 1,
                columns: new[] { "BlogUrl", "Company", "CompanyUrl", "FirstName", "GitHub", "LastName", "Twitter" },
                values: new object[] { "http://wildermuth.com", "Wilder Minds LLC", "http://wilderminds.com", "Shawn", "shawnwildermuth", "Wildermuth", "shawnwildermuth" });

            migrationBuilder.UpdateData(
                table: "Speakers",
                keyColumn: "SpeakerId",
                keyValue: 2,
                columns: new[] { "BlogUrl", "Company", "CompanyUrl", "FirstName", "GitHub", "LastName", "Twitter" },
                values: new object[] { "http://shawnandresa.com", "Wilder Minds LLC", "http://wilderminds.com", "Resa", "resawildermuth", "Wildermuth", "resawildermuth" });

            migrationBuilder.UpdateData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 1,
                columns: new[] { "Abstract", "Title" },
                values: new object[] { "Entity Framework from scratch in an hour. Probably cover it all", "Entity Framework From Scratch" });

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "TrainingId",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "ATL2018", "Atlanta Code Training" });
        }
    }
}
