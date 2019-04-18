﻿// <auto-generated />
using System;
using DeliveryService.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeliveryService.API.Migrations
{
    [DbContext(typeof(DeliveryContext))]
    [Migration("20190412004848_inputingdata")]
    partial class inputingdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeliveryService.API.Model.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Points");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "C"
                        },
                        new
                        {
                            Id = 4,
                            Name = "D"
                        },
                        new
                        {
                            Id = 5,
                            Name = "E"
                        },
                        new
                        {
                            Id = 7,
                            Name = "K"
                        });
                });

            modelBuilder.Entity("DeliveryService.API.Model.PointsConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost");

                    b.Property<int?>("DestinationId");

                    b.Property<int?>("OriginId");

                    b.Property<int>("Time");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OriginId");

                    b.ToTable("PointsConnection");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Cost = 5,
                            DestinationId = 2,
                            OriginId = 1,
                            Time = 1
                        },
                        new
                        {
                            Id = 5,
                            Cost = 10,
                            DestinationId = 3,
                            OriginId = 2,
                            Time = 2
                        },
                        new
                        {
                            Id = 6,
                            Cost = 2,
                            DestinationId = 3,
                            OriginId = 1,
                            Time = 2
                        },
                        new
                        {
                            Id = 7,
                            Cost = 20,
                            DestinationId = 4,
                            OriginId = 1,
                            Time = 4
                        },
                        new
                        {
                            Id = 8,
                            Cost = 10,
                            DestinationId = 5,
                            OriginId = 4,
                            Time = 2
                        },
                        new
                        {
                            Id = 9,
                            Cost = 15,
                            DestinationId = 3,
                            OriginId = 5,
                            Time = 3
                        },
                        new
                        {
                            Id = 10,
                            Cost = 15,
                            DestinationId = 7,
                            OriginId = 4,
                            Time = 3
                        },
                        new
                        {
                            Id = 11,
                            Cost = 10,
                            DestinationId = 5,
                            OriginId = 7,
                            Time = 2
                        },
                        new
                        {
                            Id = 12,
                            Cost = 25,
                            DestinationId = 7,
                            OriginId = 1,
                            Time = 5
                        });
                });

            modelBuilder.Entity("DeliveryService.API.Model.PointsConnection", b =>
                {
                    b.HasOne("DeliveryService.API.Model.Point", "Destination")
                        .WithMany("Destinations")
                        .HasForeignKey("DestinationId");

                    b.HasOne("DeliveryService.API.Model.Point", "Origin")
                        .WithMany("Origins")
                        .HasForeignKey("OriginId");
                });
#pragma warning restore 612, 618
        }
    }
}
