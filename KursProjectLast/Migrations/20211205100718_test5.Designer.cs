﻿// <auto-generated />
using System;
using KursProjectLast.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KursProjectLast.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211205100718_test5")]
    partial class test5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KursProjectLast.Models.Entities.Airline", b =>
                {
                    b.Property<int>("AirlineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AirlineId"));

                    b.Property<string>("AirlineName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AirlineId");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("KursProjectLast.Models.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("KursProjectLast.Models.Entities.Flight", b =>
                {
                    b.Property<int?>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("FlightId"));

                    b.Property<int?>("AirlineId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("FromId")
                        .HasColumnType("integer");

                    b.Property<int?>("NumberOfPlace")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("ToId")
                        .HasColumnType("integer");

                    b.HasKey("FlightId");

                    b.HasIndex("AirlineId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("KursProjectLast.Models.Entities.Passenger", b =>
                {
                    b.Property<int?>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("PassengerId"));

                    b.Property<string>("FinCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)");

                    b.Property<string>("Name")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Surname")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("PassengerId");

                    b.HasIndex("FinCode")
                        .IsUnique();

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("KursProjectLast.Models.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TicketId"));

                    b.Property<int>("FlightId")
                        .HasColumnType("integer");

                    b.Property<int?>("PassengerId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("TicketId");

                    b.HasIndex("FlightId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("KursProjectLast.Models.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KursProjectLast.Models.Entities.Flight", b =>
                {
                    b.HasOne("KursProjectLast.Models.Entities.Airline", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineId");

                    b.HasOne("KursProjectLast.Models.Entities.City", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("KursProjectLast.Models.Entities.City", "To")
                        .WithMany()
                        .HasForeignKey("ToId");

                    b.Navigation("Airline");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("KursProjectLast.Models.Entities.Ticket", b =>
                {
                    b.HasOne("KursProjectLast.Models.Entities.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KursProjectLast.Models.Entities.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });
#pragma warning restore 612, 618
        }
    }
}
