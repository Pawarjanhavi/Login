﻿// <auto-generated />
using System;
using Login.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Login.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241124132117_DB")]
    partial class DB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Login.Model.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<DateTime>("AvailableDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("AvailableStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("LocationId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            AvailableDate = new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            AvailableStatus = true,
                            Colour = "White",
                            Description = "5 Seater Car",
                            LicensePlate = "MP09CP7235",
                            LocationId = 2,
                            Make = "Honda",
                            Model = "Honda City",
                            PricePerDay = 3000m,
                            year = 2020
                        },
                        new
                        {
                            CarId = 2,
                            AvailableDate = new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Local),
                            AvailableStatus = true,
                            Colour = "Red",
                            Description = "5 Seater Car",
                            LicensePlate = "MH50PS2184",
                            LocationId = 1,
                            Make = "Honda",
                            Model = "Honda Amaze",
                            PricePerDay = 3200m,
                            year = 2018
                        });
                });

            modelBuilder.Entity("Login.Model.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            Address = "123,Honda Showroom",
                            City = "Mumbai",
                            Country = "India",
                            State = "Maharshtra",
                            ZipCode = "411912"
                        },
                        new
                        {
                            LocationId = 2,
                            Address = "711,Honda Showroom",
                            City = "Indore",
                            Country = "India",
                            State = "Madhya Pradesh",
                            ZipCode = "452014"
                        });
                });

            modelBuilder.Entity("Login.Model.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Login.Model.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DropOffDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Login.Model.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<DateOnly>("ReviewCreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Login.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "zahabiya@gmail.com",
                            FirstName = "Zahabiya",
                            LastName = "Kapadia",
                            Password = "z123",
                            PhoneNumber = "9128347653",
                            roleType = "Admin"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "tanya@gmail.com",
                            FirstName = "Tanya",
                            LastName = "Patel",
                            Password = "t123",
                            PhoneNumber = "9827342651",
                            roleType = "User"
                        });
                });

            modelBuilder.Entity("Login.Model.Car", b =>
                {
                    b.HasOne("Login.Model.Location", "location")
                        .WithMany("cars")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("location");
                });

            modelBuilder.Entity("Login.Model.Payment", b =>
                {
                    b.HasOne("Login.Model.Reservation", "reservation")
                        .WithMany("payments")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("reservation");
                });

            modelBuilder.Entity("Login.Model.Reservation", b =>
                {
                    b.HasOne("Login.Model.Car", "car")
                        .WithMany("reservations")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Login.Model.User", "user")
                        .WithMany("reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Login.Model.Review", b =>
                {
                    b.HasOne("Login.Model.Car", "car")
                        .WithMany("reviews")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Login.Model.User", "user")
                        .WithMany("reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Login.Model.Car", b =>
                {
                    b.Navigation("reservations");

                    b.Navigation("reviews");
                });

            modelBuilder.Entity("Login.Model.Location", b =>
                {
                    b.Navigation("cars");
                });

            modelBuilder.Entity("Login.Model.Reservation", b =>
                {
                    b.Navigation("payments");
                });

            modelBuilder.Entity("Login.Model.User", b =>
                {
                    b.Navigation("reservations");

                    b.Navigation("reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
