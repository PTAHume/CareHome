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
                    NumberStreetName = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Locality = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Town = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    PostCode = table.Column<string>(type: "VARCHAR(16)", nullable: false)
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
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeNumber = table.Column<string>(type: "VARCHAR(32)", nullable: false),
                    MobileNumber = table.Column<string>(type: "VARCHAR(32)", nullable: false),
                    EMail = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    PostCode = table.Column<string>(type: "VARCHAR(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "EthnicityGroups",
                columns: table => new
                {
                    EthnicityGroupsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthnicityGroups", x => x.EthnicityGroupsId);
                });

            migrationBuilder.CreateTable(
                name: "GenderTypes",
                columns: table => new
                {
                    GenderTypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTypes", x => x.GenderTypesId);
                });

            migrationBuilder.CreateTable(
                name: "CareHomes",
                columns: table => new
                {
                    CareHomesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(256)", nullable: false),
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
                name: "JobTitles",
                columns: table => new
                {
                    JobTitlesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    DefaultSalary = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DepartmentsDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitlesId);
                    table.ForeignKey(
                        name: "FK_JobTitles_Departments_DepartmentsDepartmentId",
                        column: x => x.DepartmentsDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EthnicityTypes",
                columns: table => new
                {
                    EthnicityTypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EthnicityName = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    EthnicityGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthnicityTypes", x => x.EthnicityTypesId);
                    table.ForeignKey(
                        name: "FK_EthnicityTypes_EthnicityGroups_EthnicityGroupsId",
                        column: x => x.EthnicityGroupsId,
                        principalTable: "EthnicityGroups",
                        principalColumn: "EthnicityGroupsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    MiddleNames = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    CareHomesId = table.Column<int>(type: "int", nullable: false),
                    GenderTypesId = table.Column<int>(type: "int", nullable: true),
                    AddressDetailsId = table.Column<int>(type: "int", nullable: true),
                    ContactDetailsId = table.Column<int>(type: "int", nullable: true),
                    EthnicityGroupsId = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    JobTitlesId = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
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
                        principalColumn: "CareHomesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_ContactDetails_ContactDetailsId",
                        column: x => x.ContactDetailsId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailsId");
                    table.ForeignKey(
                        name: "FK_Staff_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_Staff_EthnicityGroups_EthnicityGroupsId",
                        column: x => x.EthnicityGroupsId,
                        principalTable: "EthnicityGroups",
                        principalColumn: "EthnicityGroupsId");
                    table.ForeignKey(
                        name: "FK_Staff_GenderTypes_GenderTypesId",
                        column: x => x.GenderTypesId,
                        principalTable: "GenderTypes",
                        principalColumn: "GenderTypesId");
                    table.ForeignKey(
                        name: "FK_Staff_JobTitles_JobTitlesId",
                        column: x => x.JobTitlesId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitlesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CareHomes_AddressDetailsId",
                table: "CareHomes",
                column: "AddressDetailsId",
                unique: true,
                filter: "[AddressDetailsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CareHomes_ContactDetailsId",
                table: "CareHomes",
                column: "ContactDetailsId",
                unique: true,
                filter: "[ContactDetailsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EthnicityTypes_EthnicityGroupsId",
                table: "EthnicityTypes",
                column: "EthnicityGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_DepartmentsDepartmentId",
                table: "JobTitles",
                column: "DepartmentsDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_AddressDetailsId",
                table: "Staff",
                column: "AddressDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_CareHomesId",
                table: "Staff",
                column: "CareHomesId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_ContactDetailsId",
                table: "Staff",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DepartmentId",
                table: "Staff",
                column: "DepartmentId",
                unique: true,
                filter: "[DepartmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_EthnicityGroupsId",
                table: "Staff",
                column: "EthnicityGroupsId",
                unique: true,
                filter: "[EthnicityGroupsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_GenderTypesId",
                table: "Staff",
                column: "GenderTypesId",
                unique: true,
                filter: "[GenderTypesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_JobTitlesId",
                table: "Staff",
                column: "JobTitlesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EthnicityTypes");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "CareHomes");

            migrationBuilder.DropTable(
                name: "EthnicityGroups");

            migrationBuilder.DropTable(
                name: "GenderTypes");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
