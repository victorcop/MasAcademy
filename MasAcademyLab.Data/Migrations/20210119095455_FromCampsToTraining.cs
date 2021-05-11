using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasAcademyLab.Data.Migrations
{
    public partial class FromCampsToTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Camps_CampId",
                table: "Talks");

            migrationBuilder.DropTable(
                name: "Camps");

            migrationBuilder.RenameColumn(
                name: "CampId",
                table: "Talks",
                newName: "TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_Talks_CampId",
                table: "Talks",
                newName: "IX_Talks_TrainingId");

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_Trainings_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "TrainingId", "Code", "EventDate", "Length", "LocationId", "Name" },
                values: new object[] { 1, null, new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Atlanta Code Camp" });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_LocationId",
                table: "Trainings",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Trainings_TrainingId",
                table: "Talks",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "TrainingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Trainings_TrainingId",
                table: "Talks");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "Talks",
                newName: "CampId");

            migrationBuilder.RenameIndex(
                name: "IX_Talks_TrainingId",
                table: "Talks",
                newName: "IX_Talks_CampId");

            migrationBuilder.CreateTable(
                name: "Camps",
                columns: table => new
                {
                    CampId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Moniker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camps", x => x.CampId);
                    table.ForeignKey(
                        name: "FK_Camps_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Camps",
                columns: new[] { "CampId", "EventDate", "Length", "LocationId", "Moniker", "Name" },
                values: new object[] { 1, new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "ATL2018", "Atlanta Code Camp" });

            migrationBuilder.UpdateData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 1,
                column: "CampId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 2,
                column: "CampId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Camps_LocationId",
                table: "Camps",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Camps_CampId",
                table: "Talks",
                column: "CampId",
                principalTable: "Camps",
                principalColumn: "CampId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
