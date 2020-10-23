using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class BrainTeaserAdditionField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "BrainTeaserWinners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "BrainTeaserAnswers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "BrainTeaserWinners");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "BrainTeaserAnswers");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 8, 21, 1, 36, 630, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 8, 21, 1, 36, 627, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 10, 8, 21, 1, 36, 630, DateTimeKind.Local).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 8, 21, 1, 36, 631, DateTimeKind.Local).AddTicks(6955));
        }
    }
}
