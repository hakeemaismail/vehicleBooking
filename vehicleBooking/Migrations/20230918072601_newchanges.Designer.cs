﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vehicleBooking.Data;

#nullable disable

namespace vehicleBooking.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230918072601_newchanges")]
    partial class newchanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("vehicleBooking.Models.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("vehicleBooking.Models.Amenities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AmenityType")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("vehicleBooking.Models.Billing", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("PassengerId")
                        .HasColumnType("bigint");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<long>("TotalAmount")
                        .HasColumnType("bigint");

                    b.Property<long>("bookingId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("bookingId")
                        .IsUnique();

                    b.ToTable("Billing");
                });

            modelBuilder.Entity("vehicleBooking.Models.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("DropoffLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PickupLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialRequest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.Property<long?>("VehicleId")
                        .HasColumnType("bigint");

                    b.Property<long?>("chauffeurId")
                        .HasColumnType("bigint");

                    b.Property<int?>("dayCharge")
                        .HasColumnType("int");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("mileage")
                        .HasColumnType("int");

                    b.Property<int?>("noOfHours")
                        .HasColumnType("int");

                    b.Property<long?>("passengerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.HasIndex("chauffeurId");

                    b.HasIndex("passengerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("vehicleBooking.Models.BookingAmenities", b =>
                {
                    b.Property<long>("BookingId")
                        .HasColumnType("bigint");

                    b.Property<long>("AmenityId")
                        .HasColumnType("bigint");

                    b.HasKey("BookingId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("BookingAmenities");
                });

            modelBuilder.Entity("vehicleBooking.Models.Chauffeur", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("AvailabiltyStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("companyId")
                        .HasColumnType("bigint");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("companyId");

                    b.ToTable("Chauffeur");
                });

            modelBuilder.Entity("vehicleBooking.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("vehicleBooking.Models.Cost", b =>
                {
                    b.Property<long>("CostPerMile")
                        .HasColumnType("bigint");

                    b.Property<long>("DayCharge")
                        .HasColumnType("bigint");

                    b.Property<long>("HourlyRate")
                        .HasColumnType("bigint");

                    b.ToTable("Cost");
                });

            modelBuilder.Entity("vehicleBooking.Models.Feedback", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("ChauffeurRating")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassengerComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PassengerId")
                        .HasColumnType("bigint");

                    b.Property<int?>("PassengerRating")
                        .HasColumnType("int");

                    b.Property<long>("bookingId")
                        .HasColumnType("bigint");

                    b.Property<long>("chauffeurId")
                        .HasColumnType("bigint");

                    b.Property<long>("vehicleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("bookingId")
                        .IsUnique();

                    b.HasIndex("chauffeurId");

                    b.HasIndex("vehicleId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("vehicleBooking.Models.Passenger", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("vehicleBooking.Models.Vehicle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Availablity")
                        .HasColumnType("bit");

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("vehicleBooking.Models.VehicleAmenities", b =>
                {
                    b.Property<long>("VehicleId")
                        .HasColumnType("bigint");

                    b.Property<long>("AmenityId")
                        .HasColumnType("bigint");

                    b.HasKey("VehicleId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("VehicleAmenities");
                });

            modelBuilder.Entity("vehicleBooking.Models.VehicleChauffeur", b =>
                {
                    b.Property<long>("VehicleId")
                        .HasColumnType("bigint");

                    b.Property<long>("ChauffeurId")
                        .HasColumnType("bigint");

                    b.HasKey("VehicleId", "ChauffeurId");

                    b.HasIndex("ChauffeurId");

                    b.ToTable("VehicleChauffeurs");
                });

            modelBuilder.Entity("vehicleBooking.Models.Billing", b =>
                {
                    b.HasOne("vehicleBooking.Models.Passenger", "Passenger")
                        .WithMany("billings")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("vehicleBooking.Models.Booking", "booking")
                        .WithOne("billing")
                        .HasForeignKey("vehicleBooking.Models.Billing", "bookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("booking");
                });

            modelBuilder.Entity("vehicleBooking.Models.Booking", b =>
                {
                    b.HasOne("vehicleBooking.Models.Vehicle", "vehicle")
                        .WithMany("bookings")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("vehicleBooking.Models.Chauffeur", "chauffeurs")
                        .WithMany("Bookings")
                        .HasForeignKey("chauffeurId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("vehicleBooking.Models.Passenger", "passenger")
                        .WithMany("bookings")
                        .HasForeignKey("passengerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("chauffeurs");

                    b.Navigation("passenger");

                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("vehicleBooking.Models.BookingAmenities", b =>
                {
                    b.HasOne("vehicleBooking.Models.Amenities", "Amenities")
                        .WithMany("BookingAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("vehicleBooking.Models.Booking", "Booking")
                        .WithMany("BookingAmenities")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Amenities");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("vehicleBooking.Models.Chauffeur", b =>
                {
                    b.HasOne("vehicleBooking.Models.Company", "company")
                        .WithMany("Chauffeurs")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("company");
                });

            modelBuilder.Entity("vehicleBooking.Models.Feedback", b =>
                {
                    b.HasOne("vehicleBooking.Models.Passenger", "passenger")
                        .WithMany("feedbacks")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("vehicleBooking.Models.Booking", "booking")
                        .WithOne("feedback")
                        .HasForeignKey("vehicleBooking.Models.Feedback", "bookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vehicleBooking.Models.Chauffeur", "chauffeur")
                        .WithMany("feedbacks")
                        .HasForeignKey("chauffeurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("vehicleBooking.Models.Vehicle", "vehicle")
                        .WithMany("Feedbacks")
                        .HasForeignKey("vehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("booking");

                    b.Navigation("chauffeur");

                    b.Navigation("passenger");

                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("vehicleBooking.Models.VehicleAmenities", b =>
                {
                    b.HasOne("vehicleBooking.Models.Amenities", "Amenities")
                        .WithMany("VehicleAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("vehicleBooking.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleAmenities")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Amenities");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("vehicleBooking.Models.VehicleChauffeur", b =>
                {
                    b.HasOne("vehicleBooking.Models.Chauffeur", "Chauffeur")
                        .WithMany("VehicleChauffeurs")
                        .HasForeignKey("ChauffeurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("vehicleBooking.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleChauffeurs")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Chauffeur");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("vehicleBooking.Models.Amenities", b =>
                {
                    b.Navigation("BookingAmenities");

                    b.Navigation("VehicleAmenities");
                });

            modelBuilder.Entity("vehicleBooking.Models.Booking", b =>
                {
                    b.Navigation("BookingAmenities");

                    b.Navigation("billing");

                    b.Navigation("feedback");
                });

            modelBuilder.Entity("vehicleBooking.Models.Chauffeur", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("VehicleChauffeurs");

                    b.Navigation("feedbacks");
                });

            modelBuilder.Entity("vehicleBooking.Models.Company", b =>
                {
                    b.Navigation("Chauffeurs");
                });

            modelBuilder.Entity("vehicleBooking.Models.Passenger", b =>
                {
                    b.Navigation("billings");

                    b.Navigation("bookings");

                    b.Navigation("feedbacks");
                });

            modelBuilder.Entity("vehicleBooking.Models.Vehicle", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("VehicleAmenities");

                    b.Navigation("VehicleChauffeurs");

                    b.Navigation("bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
