﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nova4TestProject.Data;

#nullable disable

namespace Nova4TestProject.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Nova4TestProject.Models.BitcoinHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BitcoinInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
