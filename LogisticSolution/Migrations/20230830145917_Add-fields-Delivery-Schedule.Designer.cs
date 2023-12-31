﻿// <auto-generated />
using System;
using LogisticSolution.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogisticSolution.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230830145917_Add-fields-Delivery-Schedule")]
    partial class AddfieldsDeliverySchedule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LogisticSolution.Models.DeliverySchedule", b =>
                {
                    b.Property<int>("DeliveryScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryScheduleId"), 1L, 1);

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("GuideNumber")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("date");

                    b.Property<string>("TransportId")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DeliveryScheduleId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("DeliverySchedules");
                });

            modelBuilder.Entity("LogisticSolution.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<int>("LocationType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("LogisticSolution.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("LogisticSolution.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LogisticSolution.Models.DeliverySchedule", b =>
                {
                    b.HasOne("LogisticSolution.Models.Location", "Location")
                        .WithMany("DeliverySchedules")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticSolution.Models.ProductCategory", "ProductCategory")
                        .WithMany("DeliverySchedules")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticSolution.Models.User", "User")
                        .WithMany("DeliverySchedules")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("ProductCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LogisticSolution.Models.Location", b =>
                {
                    b.Navigation("DeliverySchedules");
                });

            modelBuilder.Entity("LogisticSolution.Models.ProductCategory", b =>
                {
                    b.Navigation("DeliverySchedules");
                });

            modelBuilder.Entity("LogisticSolution.Models.User", b =>
                {
                    b.Navigation("DeliverySchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
