﻿// <auto-generated />
using System;
using AwingApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AwingApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20250419152749_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AwingApi.Entities.CalculationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("M")
                        .HasColumnType("int");

                    b.Property<string>("Matrix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("N")
                        .HasColumnType("int");

                    b.Property<int>("P")
                        .HasColumnType("int");

                    b.Property<int>("Resutl")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CalculationLog");
                });
#pragma warning restore 612, 618
        }
    }
}
