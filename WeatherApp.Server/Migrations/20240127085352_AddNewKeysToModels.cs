using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddNewKeysToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_CurrentWeatherCalls_CurrentWeatherId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_FiveDaysWeahterCalls_FiveDaysWeatherId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_TenantID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TenantID",
                table: "Users",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TenantID",
                table: "Users",
                newName: "IX_Users_TenantId");

            migrationBuilder.AlterColumn<Guid>(
                name: "FiveDaysWeatherId",
                table: "Records",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentWeatherId",
                table: "Records",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Records",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "FiveDaysWeahterCalls",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "CurrentWeatherCalls",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Records_TenantId",
                table: "Records",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FiveDaysWeahterCalls_TenantId",
                table: "FiveDaysWeahterCalls",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentWeatherCalls_TenantId",
                table: "CurrentWeatherCalls",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentWeatherCalls_Tenants_TenantId",
                table: "CurrentWeatherCalls",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FiveDaysWeahterCalls_Tenants_TenantId",
                table: "FiveDaysWeahterCalls",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_CurrentWeatherCalls_CurrentWeatherId",
                table: "Records",
                column: "CurrentWeatherId",
                principalTable: "CurrentWeatherCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_FiveDaysWeahterCalls_FiveDaysWeatherId",
                table: "Records",
                column: "FiveDaysWeatherId",
                principalTable: "FiveDaysWeahterCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Tenants_TenantId",
                table: "Records",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentWeatherCalls_Tenants_TenantId",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_FiveDaysWeahterCalls_Tenants_TenantId",
                table: "FiveDaysWeahterCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_CurrentWeatherCalls_CurrentWeatherId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_FiveDaysWeahterCalls_FiveDaysWeatherId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Tenants_TenantId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Records_TenantId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_FiveDaysWeahterCalls_TenantId",
                table: "FiveDaysWeahterCalls");

            migrationBuilder.DropIndex(
                name: "IX_CurrentWeatherCalls_TenantId",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "FiveDaysWeahterCalls");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CurrentWeatherCalls");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Users",
                newName: "TenantID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                newName: "IX_Users_TenantID");

            migrationBuilder.AlterColumn<Guid>(
                name: "FiveDaysWeatherId",
                table: "Records",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentWeatherId",
                table: "Records",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_CurrentWeatherCalls_CurrentWeatherId",
                table: "Records",
                column: "CurrentWeatherId",
                principalTable: "CurrentWeatherCalls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_FiveDaysWeahterCalls_FiveDaysWeatherId",
                table: "Records",
                column: "FiveDaysWeatherId",
                principalTable: "FiveDaysWeahterCalls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_TenantID",
                table: "Users",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
