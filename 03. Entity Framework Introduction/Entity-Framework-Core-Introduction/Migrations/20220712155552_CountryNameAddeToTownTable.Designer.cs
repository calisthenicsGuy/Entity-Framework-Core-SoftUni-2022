﻿// <auto-generated />
using System;
using Entity_Framework_Core_Introduction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entity_Framework_Core_Introduction.Migrations
{
    [DbContext(typeof(SoftUniContext))]
    [Migration("20220712155552_CountryNameAddeToTownTable")]
    partial class CountryNameAddeToTownTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AddressID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("TownId")
                        .HasColumnType("int")
                        .HasColumnName("TownID");

                    b.HasKey("AddressId");

                    b.HasIndex("TownId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int")
                        .HasColumnName("ManagerID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("DepartmentId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int")
                        .HasColumnName("ManagerID");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AddressId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.EmployeesProject", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectID");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeesProjects");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProjectID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Town", b =>
                {
                    b.Property<int>("TownId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TownID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TownId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Address", b =>
                {
                    b.HasOne("Entity_Framework_Core_Introduction.Models.Town", "Town")
                        .WithMany("Addresses")
                        .HasForeignKey("TownId")
                        .HasConstraintName("FK_Addresses_Towns");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Department", b =>
                {
                    b.HasOne("Entity_Framework_Core_Introduction.Models.Employee", "Manager")
                        .WithMany("Departments")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK_Departments_Employees")
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Employee", b =>
                {
                    b.HasOne("Entity_Framework_Core_Introduction.Models.Address", "Address")
                        .WithMany("Employees")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_Employees_Addresses");

                    b.HasOne("Entity_Framework_Core_Introduction.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Employees_Departments")
                        .IsRequired();

                    b.HasOne("Entity_Framework_Core_Introduction.Models.Employee", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK_Employees_Employees");

                    b.Navigation("Address");

                    b.Navigation("Department");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.EmployeesProject", b =>
                {
                    b.HasOne("Entity_Framework_Core_Introduction.Models.Employee", "Employee")
                        .WithMany("EmployeesProjects")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_EmployeesProjects_Employees")
                        .IsRequired();

                    b.HasOne("Entity_Framework_Core_Introduction.Models.Project", "Project")
                        .WithMany("EmployeesProjects")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_EmployeesProjects_Projects")
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Address", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Employee", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("EmployeesProjects");

                    b.Navigation("InverseManager");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Project", b =>
                {
                    b.Navigation("EmployeesProjects");
                });

            modelBuilder.Entity("Entity_Framework_Core_Introduction.Models.Town", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
