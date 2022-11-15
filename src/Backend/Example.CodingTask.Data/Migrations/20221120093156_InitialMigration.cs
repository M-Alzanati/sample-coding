using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cleverbit.CodingTask.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMatches",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatches", x => new { x.UserId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_UserMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMatches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Name", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("d6b54753-e71d-4521-a89b-8aab0ea209c4"), "Match A", new DateTime(2022, 11, 20, 11, 34, 56, 190, DateTimeKind.Local).AddTicks(927) },
                    { new Guid("3fac18da-97bb-4890-bf61-54d2cdc3385c"), "Match F", new DateTime(2022, 11, 20, 11, 36, 56, 190, DateTimeKind.Local).AddTicks(6384) },
                    { new Guid("81ceba72-b1fc-4bec-aa9c-98c26639c87d"), "Match B", new DateTime(2022, 11, 20, 11, 38, 56, 190, DateTimeKind.Local).AddTicks(6407) },
                    { new Guid("dc54642a-b550-4434-971e-be686be93a59"), "Match C", new DateTime(2022, 11, 20, 11, 39, 56, 190, DateTimeKind.Local).AddTicks(6409) },
                    { new Guid("9b81c707-b0d9-497f-9a19-2647c3941acb"), "Match D", new DateTime(2022, 11, 20, 11, 41, 56, 190, DateTimeKind.Local).AddTicks(6411) },
                    { new Guid("40101467-c365-4af1-a9a8-cc253b74d58b"), "Match E", new DateTime(2022, 11, 20, 11, 42, 56, 190, DateTimeKind.Local).AddTicks(6415) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMatches_MatchId",
                table: "UserMatches",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMatches");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
