using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareHome.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressDetails",
                columns: table => new
                {
                    AddressDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberStreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetails", x => x.AddressDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitlesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultSalery = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitlesId);
                });

            migrationBuilder.CreateTable(
                name: "CareHomes",
                columns: table => new
                {
                    CareHomesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressDetailsId = table.Column<int>(type: "int", nullable: true),
                    ContactDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareHomes", x => x.CareHomesId);
                    table.ForeignKey(
                        name: "FK_CareHomes_AddressDetails_AddressDetailsId",
                        column: x => x.AddressDetailsId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailsId");
                    table.ForeignKey(
                        name: "FK_CareHomes_ContactDetails_ContactDetailsId",
                        column: x => x.ContactDetailsId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailsId");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_JobTitles_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitlesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareHomesId = table.Column<int>(type: "int", nullable: true),
                    AddressDetailsId = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTitlesId = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_AddressDetails_AddressDetailsId",
                        column: x => x.AddressDetailsId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailsId");
                    table.ForeignKey(
                        name: "FK_Staff_CareHomes_CareHomesId",
                        column: x => x.CareHomesId,
                        principalTable: "CareHomes",
                        principalColumn: "CareHomesId");
                    table.ForeignKey(
                        name: "FK_Staff_JobTitles_JobTitlesId",
                        column: x => x.JobTitlesId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitlesId");
                });

            migrationBuilder.CreateTable(
                name: "EthnicityGroups",
                columns: table => new
                {
                    EthnicityGroupsId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthnicityGroups", x => x.EthnicityGroupsId);
                    table.ForeignKey(
                        name: "FK_EthnicityGroups_Staff_EthnicityGroupsId",
                        column: x => x.EthnicityGroupsId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenderTypes",
                columns: table => new
                {
                    GenderTypesId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTypes", x => x.GenderTypesId);
                    table.ForeignKey(
                        name: "FK_GenderTypes_Staff_GenderTypesId",
                        column: x => x.GenderTypesId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EthnicityTypes",
                columns: table => new
                {
                    EthnicityTypesId = table.Column<int>(type: "int", nullable: false),
                    EthnicityName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthnicityTypes", x => x.EthnicityTypesId);
                    table.ForeignKey(
                        name: "FK_EthnicityTypes_EthnicityGroups_EthnicityTypesId",
                        column: x => x.EthnicityTypesId,
                        principalTable: "EthnicityGroups",
                        principalColumn: "EthnicityGroupsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CareHomes_AddressDetailsId",
                table: "CareHomes",
                column: "AddressDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CareHomes_ContactDetailsId",
                table: "CareHomes",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_AddressDetailsId",
                table: "Staff",
                column: "AddressDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_CareHomesId",
                table: "Staff",
                column: "CareHomesId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_JobTitlesId",
                table: "Staff",
                column: "JobTitlesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EthnicityTypes");

            migrationBuilder.DropTable(
                name: "GenderTypes");

            migrationBuilder.DropTable(
                name: "EthnicityGroups");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "CareHomes");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropTable(
                name: "ContactDetails");
        }
    }
}
