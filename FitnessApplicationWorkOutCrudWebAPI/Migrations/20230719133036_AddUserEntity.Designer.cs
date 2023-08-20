﻿// <auto-generated />
using System;
using FitnessApplicationWorkOutCrudWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitnessApplicationWorkOutCrudWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230719133036_AddUserEntity")]
    partial class AddUserEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitnessApplicationWorkOutCrudWebAPI.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FitnessApplicationWorkOutCrudWebAPI.WorkOutDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CheatMeal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<string>("WorkOut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WorkOutDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("WorkOutDuration")
                        .HasColumnType("float");

                    b.Property<string>("WorkOutType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkOutDetails");
                });

            modelBuilder.Entity("FitnessApplicationWorkOutCrudWebAPI.WorkOutDetail", b =>
                {
                    b.HasOne("FitnessApplicationWorkOutCrudWebAPI.User", "User")
                        .WithMany("UserWorkOutDetails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessApplicationWorkOutCrudWebAPI.User", b =>
                {
                    b.Navigation("UserWorkOutDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
