using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class TablesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_People_PersonId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PersonId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Pets",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBuying",
                table: "Pets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OwnerEGN",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OwnerPersonId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "People",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "EGN",
                table: "People",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                columns: new[] { "PersonId", "EGN" });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerPersonId_OwnerEGN",
                table: "Pets",
                columns: new[] { "OwnerPersonId", "OwnerEGN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_People_OwnerPersonId_OwnerEGN",
                table: "Pets",
                columns: new[] { "OwnerPersonId", "OwnerEGN" },
                principalTable: "People",
                principalColumns: new[] { "PersonId", "EGN" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_People_OwnerPersonId_OwnerEGN",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_OwnerPersonId_OwnerEGN",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DateOfBuying",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "OwnerEGN",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "OwnerPersonId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "EGN",
                table: "People");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Pets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "People",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PersonId",
                table: "Pets",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_People_PersonId",
                table: "Pets",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
