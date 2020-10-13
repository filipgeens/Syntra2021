using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedAir.Models.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AircraftType",
                schema: "dbo",
                columns: table => new
                {
                    TypeID = table.Column<byte>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Airline",
                schema: "dbo",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    FoundingYear = table.Column<int>(nullable: true),
                    Bunkrupt = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DepartureGrouping",
                schema: "dbo",
                columns: table => new
                {
                    Departure = table.Column<string>(nullable: false),
                    FlightCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartureGrouping", x => x.Departure);
                });

            migrationBuilder.CreateTable(
                name: "Persondetail",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Memo = table.Column<string>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    Street = table.Column<string>(maxLength: 30, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    Country = table.Column<string>(maxLength: 3, nullable: true),
                    Postcode = table.Column<string>(maxLength: 8, nullable: true),
                    Planet = table.Column<string>(maxLength: 130, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persondetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "V_DepartureStatistics",
                schema: "dbo",
                columns: table => new
                {
                    Departure = table.Column<string>(nullable: false),
                    FlightCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_DepartureStatistics", x => x.Departure);
                });

            migrationBuilder.CreateTable(
                name: "AircraftTypeDetail",
                schema: "dbo",
                columns: table => new
                {
                    AircraftTypeID = table.Column<byte>(nullable: false),
                    TurbineCount = table.Column<byte>(nullable: true),
                    Length = table.Column<float>(nullable: true),
                    Tare = table.Column<short>(nullable: true),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTypeDetail", x => x.AircraftTypeID);
                    table.ForeignKey(
                        name: "FK_AircraftTypeDetail_AircraftType_AircraftTypeID",
                        column: x => x.AircraftTypeID,
                        principalSchema: "dbo",
                        principalTable: "AircraftType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "dbo",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birthday = table.Column<DateTime>(nullable: true),
                    DetailID = table.Column<int>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    Salary = table.Column<float>(nullable: false),
                    SupervisorPersonID = table.Column<int>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    LicenseDate = table.Column<DateTime>(nullable: true),
                    FlightHours = table.Column<int>(nullable: true),
                    PilotLicenseType = table.Column<string>(nullable: true),
                    FlightSchool = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Employee_Persondetail_DetailID",
                        column: x => x.DetailID,
                        principalSchema: "dbo",
                        principalTable: "Persondetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_SupervisorPersonID",
                        column: x => x.SupervisorPersonID,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                schema: "dbo",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birthday = table.Column<DateTime>(nullable: true),
                    DetailID = table.Column<int>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    CustomerSince = table.Column<DateTime>(nullable: true),
                    FrequentFlyer = table.Column<bool>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Passenger_Persondetail_DetailID",
                        column: x => x.DetailID,
                        principalSchema: "dbo",
                        principalTable: "Persondetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                schema: "dbo",
                columns: table => new
                {
                    FlightNo = table.Column<int>(nullable: false),
                    Departure = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "(N'(not set)')"),
                    Destination = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "(N'(not set)')"),
                    FlightDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    NonSmokingFlight = table.Column<bool>(nullable: true),
                    Seats = table.Column<short>(nullable: false),
                    FreeSeats = table.Column<short>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true, defaultValueSql: "((123.45))"),
                    Memo = table.Column<string>(nullable: true),
                    Strikebound = table.Column<bool>(nullable: true),
                    Utilization = table.Column<decimal>(type: "numeric(20, 8)", nullable: true, computedColumnSql: "((100.0)-(([FreeSeats]*(1.0))/[Seats])*(100.0))"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AirlineCode = table.Column<string>(maxLength: 3, nullable: true),
                    PilotId = table.Column<int>(nullable: false),
                    CopilotId = table.Column<int>(nullable: true),
                    AircraftTypeID = table.Column<byte>(nullable: true),
                    LastChange = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightNo);
                    table.ForeignKey(
                        name: "FK_Flight_AircraftType_AircraftTypeID",
                        column: x => x.AircraftTypeID,
                        principalSchema: "dbo",
                        principalTable: "AircraftType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineCode",
                        column: x => x.AirlineCode,
                        principalSchema: "dbo",
                        principalTable: "Airline",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Employee_CopilotId",
                        column: x => x.CopilotId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Employee_PilotId",
                        column: x => x.PilotId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                schema: "dbo",
                columns: table => new
                {
                    FlightNo = table.Column<int>(nullable: false),
                    PassengerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => new { x.FlightNo, x.PassengerID });
                    table.ForeignKey(
                        name: "FK_Booking_Flight_FlightNo",
                        column: x => x.FlightNo,
                        principalSchema: "dbo",
                        principalTable: "Flight",
                        principalColumn: "FlightNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Passenger_PassengerID",
                        column: x => x.PassengerID,
                        principalSchema: "dbo",
                        principalTable: "Passenger",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PassengerID",
                schema: "dbo",
                table: "Booking",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DetailID",
                schema: "dbo",
                table: "Employee",
                column: "DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SupervisorPersonID",
                schema: "dbo",
                table: "Employee",
                column: "SupervisorPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AircraftTypeID",
                schema: "dbo",
                table: "Flight",
                column: "AircraftTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineCode",
                schema: "dbo",
                table: "Flight",
                column: "AirlineCode");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_CopilotId",
                schema: "dbo",
                table: "Flight",
                column: "CopilotId");

            migrationBuilder.CreateIndex(
                name: "Index_FreeSeats",
                schema: "dbo",
                table: "Flight",
                column: "FreeSeats");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PilotId",
                schema: "dbo",
                table: "Flight",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_Departure_Destination",
                schema: "dbo",
                table: "Flight",
                columns: new[] { "Departure", "Destination" });

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_DetailID",
                schema: "dbo",
                table: "Passenger",
                column: "DetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftTypeDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Booking",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DepartureGrouping",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "V_DepartureStatistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Flight",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Passenger",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AircraftType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Airline",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Persondetail",
                schema: "dbo");
        }
    }
}
