using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class VacancyUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_jobCategories_JobCategoryId",
                table: "Vacancies");

            migrationBuilder.AlterColumn<int>(
                name: "JobCategoryId",
                table: "Vacancies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 4, 18, 49, 11, 915, DateTimeKind.Local).AddTicks(983));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 4, 18, 49, 11, 912, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 11, 4, 18, 49, 11, 914, DateTimeKind.Local).AddTicks(6502));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 4, 18, 49, 11, 915, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_jobCategories_JobCategoryId",
                table: "Vacancies",
                column: "JobCategoryId",
                principalSchema: "arenas",
                principalTable: "jobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_jobCategories_JobCategoryId",
                table: "Vacancies");

            migrationBuilder.AlterColumn<int>(
                name: "JobCategoryId",
                table: "Vacancies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
