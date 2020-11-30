using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class CompanyJobCategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Vacancies");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Vacancies",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Vacancies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpired",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Vacancies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisplayed",
                table: "Vacancies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "JobCategoryId",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobExperiences",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobResponsibilities",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobSkills",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobSummary",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobType",
                table: "Vacancies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "KeyPerformance",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequiredKnowledge",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salary",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Articles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDisplayed = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                schema: "arenas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    IsDisplayed = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 2, 18, 59, 8, 254, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 2, 18, 59, 8, 251, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 11, 2, 18, 59, 8, 254, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 2, 18, 59, 8, 255, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_JobCategoryId",
                table: "Vacancies",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AppUsers_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_companies_CompanyId",
                table: "Vacancies",
                column: "CompanyId",
                principalSchema: "arenas",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_JobCategorys_JobCategoryId",
                table: "Vacancies",
                column: "JobCategoryId",
                principalTable: "JobCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AppUsers_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_companies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_JobCategorys_JobCategoryId",
                table: "Vacancies");

            migrationBuilder.DropTable(
                name: "JobCategorys");

            migrationBuilder.DropTable(
                name: "companies",
                schema: "arenas");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_JobCategoryId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "DateExpired",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "IsDisplayed",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "JobCategoryId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "JobExperiences",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "JobResponsibilities",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "JobSkills",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "JobSummary",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "KeyPerformance",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RequiredKnowledge",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
