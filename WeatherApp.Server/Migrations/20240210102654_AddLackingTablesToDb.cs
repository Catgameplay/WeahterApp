using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddLackingTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_FiveDaysWeahterCalls_FiveDaysWeatherId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "FiveDaysWeahterCalls");

            migrationBuilder.AddColumn<double>(
                name: "CloudsAll",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Humidity",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pressure",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Temp",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WindSpeed",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "FiveDaysWeatherCalls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CityName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lat = table.Column<double>(type: "double", nullable: false),
                    Lon = table.Column<double>(type: "double", nullable: false),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<int>(type: "int", nullable: false),
                    Sunrise = table.Column<int>(type: "int", nullable: false),
                    Sunset = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiveDaysWeatherCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiveDaysWeatherCalls_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FiveDaysWeatherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Dt = table.Column<int>(type: "int", nullable: false),
                    Temp = table.Column<double>(type: "double", nullable: false),
                    FeelsLike = table.Column<double>(type: "double", nullable: false),
                    TempMin = table.Column<double>(type: "double", nullable: false),
                    TempMax = table.Column<double>(type: "double", nullable: false),
                    Pressure = table.Column<int>(type: "int", nullable: false),
                    SeaLevel = table.Column<int>(type: "int", nullable: false),
                    GroundLevel = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    MinMaxTempDiff = table.Column<double>(type: "double", nullable: false),
                    WeatherMain = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeatherDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeatherIcon = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    Pop = table.Column<double>(type: "double", nullable: false),
                    Rain = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Snow = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CloudsAll = table.Column<int>(type: "int", nullable: false),
                    WindSpeed = table.Column<double>(type: "double", nullable: false),
                    WindDeg = table.Column<int>(type: "int", nullable: false),
                    WindGust = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_FiveDaysWeatherCalls_FiveDaysWeatherId",
                        column: x => x.FiveDaysWeatherId,
                        principalTable: "FiveDaysWeatherCalls",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FiveDaysWeatherCalls_TenantId",
                table: "FiveDaysWeatherCalls",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_FiveDaysWeatherId",
                table: "Items",
                column: "FiveDaysWeatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_FiveDaysWeatherCalls_FiveDaysWeatherId",
                table: "Records",
                column: "FiveDaysWeatherId",
                principalTable: "FiveDaysWeatherCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_FiveDaysWeatherCalls_FiveDaysWeatherId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "FiveDaysWeatherCalls");

            migrationBuilder.DropColumn(
                name: "CloudsAll",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Pressure",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Temp",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "WindSpeed",
                table: "CurrentWeatherCalls");

            migrationBuilder.CreateTable(
                name: "FiveDaysWeahterCalls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiveDaysWeahterCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiveDaysWeahterCalls_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FiveDaysWeahterCalls_TenantId",
                table: "FiveDaysWeahterCalls",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_FiveDaysWeahterCalls_FiveDaysWeatherId",
                table: "Records",
                column: "FiveDaysWeatherId",
                principalTable: "FiveDaysWeahterCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
