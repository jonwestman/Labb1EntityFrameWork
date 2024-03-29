﻿// <auto-generated />
using System;
using Labb1EntityFrameWork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb1EntityFrameWork.Migrations
{
    [DbContext(typeof(VacationContext))]
    [Migration("20230420053519_thirdMigration")]
    partial class thirdMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb1EntityFrameWork.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Labb1EntityFrameWork.Models.Vacation", b =>
                {
                    b.Property<int>("VacationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationId"));

                    b.Property<string>("VacayType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VacationId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("Labb1EntityFrameWork.Models.VacationList", b =>
                {
                    b.Property<int>("VacationListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationListId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FK_VacationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VacationListId");

                    b.HasIndex("FK_EmployeeId");

                    b.HasIndex("FK_VacationId");

                    b.ToTable("VacationLists");
                });

            modelBuilder.Entity("Labb1EntityFrameWork.Models.VacationList", b =>
                {
                    b.HasOne("Labb1EntityFrameWork.Models.Employee", "Employees")
                        .WithMany("VacationLists")
                        .HasForeignKey("FK_EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb1EntityFrameWork.Models.Vacation", "Vacations")
                        .WithMany("VacationLists")
                        .HasForeignKey("FK_VacationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Vacations");
                });

            modelBuilder.Entity("Labb1EntityFrameWork.Models.Employee", b =>
                {
                    b.Navigation("VacationLists");
                });

            modelBuilder.Entity("Labb1EntityFrameWork.Models.Vacation", b =>
                {
                    b.Navigation("VacationLists");
                });
#pragma warning restore 612, 618
        }
    }
}
