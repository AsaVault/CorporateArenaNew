using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class QuestionAddedToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "arenas");

            migrationBuilder.CreateTable(
                name: "questions",
                schema: "arenas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    IsDisplayed = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "questionanswers",
                schema: "arenas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    IsDisplayed = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionanswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questionanswers_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "arenas",
                        principalTable: "questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_questionanswers_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questionoptions",
                schema: "arenas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    OptionLetter = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    IsDisplayed = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questionoptions_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "arenas",
                        principalTable: "questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 20, 19, 26, 50, 423, DateTimeKind.Local).AddTicks(3811));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 20, 19, 26, 50, 420, DateTimeKind.Local).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 10, 20, 19, 26, 50, 422, DateTimeKind.Local).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 20, 19, 26, 50, 424, DateTimeKind.Local).AddTicks(2649));

            migrationBuilder.CreateIndex(
                name: "IX_questionanswers_QuestionId",
                schema: "arenas",
                table: "questionanswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_questionanswers_UserId",
                schema: "arenas",
                table: "questionanswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_questionoptions_QuestionId",
                schema: "arenas",
                table: "questionoptions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questionanswers",
                schema: "arenas");

            migrationBuilder.DropTable(
                name: "questionoptions",
                schema: "arenas");

            migrationBuilder.DropTable(
                name: "questions",
                schema: "arenas");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 10, 18, 43, 35, 617, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 10, 18, 43, 35, 611, DateTimeKind.Local).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 10, 10, 18, 43, 35, 615, DateTimeKind.Local).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 10, 18, 43, 35, 618, DateTimeKind.Local).AddTicks(7237));
        }
    }
}
