using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class CompanyUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_JobCategorys_JobCategoryId",
                table: "Vacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCategorys",
                table: "JobCategorys");

            migrationBuilder.RenameTable(
                name: "JobCategorys",
                newName: "jobCategories",
                newSchema: "arenas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobCategories",
                schema: "arenas",
                table: "jobCategories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 4, 17, 36, 40, 644, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 4, 17, 36, 40, 641, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 11, 4, 17, 36, 40, 643, DateTimeKind.Local).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 4, 17, 36, 40, 644, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_jobCategories_JobCategoryId",
                table: "Vacancies",
                column: "JobCategoryId",
                principalSchema: "arenas",
                principalTable: "jobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_jobCategories_JobCategoryId",
                table: "Vacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobCategories",
                schema: "arenas",
                table: "jobCategories");

            migrationBuilder.RenameTable(
                name: "jobCategories",
                schema: "arenas",
                newName: "JobCategorys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCategorys",
                table: "JobCategorys",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_JobCategorys_JobCategoryId",
                table: "Vacancies",
                column: "JobCategoryId",
                principalTable: "JobCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
