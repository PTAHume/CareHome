﻿// <auto-generated />
using System;
using CareHome.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CareHome.Migrations
{
    [DbContext(typeof(CareHomeContext))]
    partial class CareHomeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CareHome.Models.AddressDetails", b =>
                {
                    b.Property<int>("AddressDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressDetailsId"), 1L, 1);

                    b.Property<string>("Locality")
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("NumberStreetName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("VARCHAR(16)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("AddressDetailsId");

                    b.ToTable("AddressDetails");
                });

            modelBuilder.Entity("CareHome.Models.CareHomes", b =>
                {
                    b.Property<int>("CareHomesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareHomesId"), 1L, 1);

                    b.Property<int?>("AddressDetailsId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("CareHomesId");

                    b.HasIndex("AddressDetailsId")
                        .IsUnique()
                        .HasFilter("[AddressDetailsId] IS NOT NULL");

                    b.HasIndex("ContactDetailsId")
                        .IsUnique()
                        .HasFilter("[ContactDetailsId] IS NOT NULL");

                    b.ToTable("CareHomes");
                });

            modelBuilder.Entity("CareHome.Models.ContactDetails", b =>
                {
                    b.Property<int>("ContactDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactDetailsId"), 1L, 1);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("PrimaryNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("VARCHAR(32)");

                    b.Property<string>("SecondaryNumber")
                        .HasMaxLength(32)
                        .HasColumnType("VARCHAR(32)");

                    b.HasKey("ContactDetailsId");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("CareHome.Models.Departments", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CareHome.Models.EthnicityGroups", b =>
                {
                    b.Property<int>("EthnicityGroupsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EthnicityGroupsId"), 1L, 1);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("EthnicityGroupsId");

                    b.ToTable("EthnicityGroups");
                });

            modelBuilder.Entity("CareHome.Models.EthnicityTypes", b =>
                {
                    b.Property<int>("EthnicityTypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EthnicityTypesId"), 1L, 1);

                    b.Property<int>("EthnicityGroupsId")
                        .HasColumnType("int");

                    b.Property<string>("EthnicityName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("EthnicityTypesId");

                    b.HasIndex("EthnicityGroupsId");

                    b.ToTable("EthnicityTypes");
                });

            modelBuilder.Entity("CareHome.Models.GenderTypes", b =>
                {
                    b.Property<int>("GenderTypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderTypesId"), 1L, 1);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("GenderTypesId");

                    b.ToTable("GenderTypes");
                });

            modelBuilder.Entity("CareHome.Models.JobTitles", b =>
                {
                    b.Property<int>("JobTitlesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobTitlesId"), 1L, 1);

                    b.Property<decimal>("DefaultSalary")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int>("DepartmentsDepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("JobTitlesId");

                    b.HasIndex("DepartmentsDepartmentId");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("CareHome.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"), 1L, 1);

                    b.Property<int?>("AddressDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("CareHomesId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactDetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EthnicityGroupsId")
                        .HasColumnType("int");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<int?>("GenderTypesId")
                        .HasColumnType("int");

                    b.Property<int?>("JobTitlesId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("MiddleNames")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("StaffId");

                    b.HasIndex("AddressDetailsId");

                    b.HasIndex("CareHomesId");

                    b.HasIndex("ContactDetailsId");

                    b.HasIndex("DepartmentId")
                        .IsUnique()
                        .HasFilter("[DepartmentId] IS NOT NULL");

                    b.HasIndex("EthnicityGroupsId")
                        .IsUnique()
                        .HasFilter("[EthnicityGroupsId] IS NOT NULL");

                    b.HasIndex("GenderTypesId")
                        .IsUnique()
                        .HasFilter("[GenderTypesId] IS NOT NULL");

                    b.HasIndex("JobTitlesId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("CareHome.Models.CareHomes", b =>
                {
                    b.HasOne("CareHome.Models.AddressDetails", "AddressDetails")
                        .WithOne("CareHomes")
                        .HasForeignKey("CareHome.Models.CareHomes", "AddressDetailsId");

                    b.HasOne("CareHome.Models.ContactDetails", "ContactInfo")
                        .WithOne("CareHomes")
                        .HasForeignKey("CareHome.Models.CareHomes", "ContactDetailsId");

                    b.Navigation("AddressDetails");

                    b.Navigation("ContactInfo");
                });

            modelBuilder.Entity("CareHome.Models.EthnicityTypes", b =>
                {
                    b.HasOne("CareHome.Models.EthnicityGroups", "EthnicityGroups")
                        .WithMany("EthnicityClasses")
                        .HasForeignKey("EthnicityGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EthnicityGroups");
                });

            modelBuilder.Entity("CareHome.Models.JobTitles", b =>
                {
                    b.HasOne("CareHome.Models.Departments", "Departments")
                        .WithMany("JobTitles")
                        .HasForeignKey("DepartmentsDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("CareHome.Models.Staff", b =>
                {
                    b.HasOne("CareHome.Models.AddressDetails", "AddressDetails")
                        .WithMany()
                        .HasForeignKey("AddressDetailsId");

                    b.HasOne("CareHome.Models.CareHomes", "CareHomes")
                        .WithMany("StaffMembers")
                        .HasForeignKey("CareHomesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareHome.Models.ContactDetails", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactDetailsId");

                    b.HasOne("CareHome.Models.Departments", "Department")
                        .WithOne("Staff")
                        .HasForeignKey("CareHome.Models.Staff", "DepartmentId");

                    b.HasOne("CareHome.Models.EthnicityGroups", "Ethnicity")
                        .WithOne("Staff")
                        .HasForeignKey("CareHome.Models.Staff", "EthnicityGroupsId");

                    b.HasOne("CareHome.Models.GenderTypes", "Gender")
                        .WithOne("Staff")
                        .HasForeignKey("CareHome.Models.Staff", "GenderTypesId");

                    b.HasOne("CareHome.Models.JobTitles", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitlesId");

                    b.Navigation("AddressDetails");

                    b.Navigation("CareHomes");

                    b.Navigation("ContactInfo");

                    b.Navigation("Department");

                    b.Navigation("Ethnicity");

                    b.Navigation("Gender");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("CareHome.Models.AddressDetails", b =>
                {
                    b.Navigation("CareHomes");
                });

            modelBuilder.Entity("CareHome.Models.CareHomes", b =>
                {
                    b.Navigation("StaffMembers");
                });

            modelBuilder.Entity("CareHome.Models.ContactDetails", b =>
                {
                    b.Navigation("CareHomes");
                });

            modelBuilder.Entity("CareHome.Models.Departments", b =>
                {
                    b.Navigation("JobTitles");

                    b.Navigation("Staff")
                        .IsRequired();
                });

            modelBuilder.Entity("CareHome.Models.EthnicityGroups", b =>
                {
                    b.Navigation("EthnicityClasses");

                    b.Navigation("Staff")
                        .IsRequired();
                });

            modelBuilder.Entity("CareHome.Models.GenderTypes", b =>
                {
                    b.Navigation("Staff")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
