﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Data.Context;

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(SacramentMeetingPlannerContext))]
    [Migration("20190413025419_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SacramentMeeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClosingHymn");

                    b.Property<string>("ClosingPlayer")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Conductor")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("OpeningHymn");

                    b.Property<string>("OpeningPlayer")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SacramentHymn");

                    b.Property<string>("Speaker1Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Speaker2Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Speaker3Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Topic1")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Topic2")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Topic3")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SacramentMeeting");
                });
#pragma warning restore 612, 618
        }
    }
}
