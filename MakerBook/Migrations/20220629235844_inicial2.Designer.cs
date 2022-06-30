﻿// <auto-generated />
using System;
using MakerBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MakerBook.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220629235844_inicial2")]
    partial class inicial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MakerBook.Models.CategoryModel", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Image");

                    b.Property<string>("ImageExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImageExtension");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImageName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MakerBook.Models.CustomerModel", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("MakerBook.Models.OrderModel", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("OrderDate");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int")
                        .HasColumnName("PaymentType");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("ServiceId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MakerBook.Models.ProfessionalAddressModel", b =>
                {
                    b.Property<int>("ProfessionalAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfessionalAddressId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessionalAddressId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

                    b.Property<string>("ComplementAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ComplementAddress");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Country");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<double>("Latitude")
                        .HasColumnType("float")
                        .HasColumnName("Latitude");

                    b.Property<string>("LineAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LineAddress");

                    b.Property<double>("Longitude")
                        .HasColumnType("float")
                        .HasColumnName("Longitude");

                    b.Property<int?>("ProfessionalId")
                        .HasColumnType("int")
                        .HasColumnName("ProfessionalId");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("State");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ZipCode");

                    b.HasKey("ProfessionalAddressId");

                    b.HasIndex("ProfessionalId");

                    b.ToTable("ProfessionalAddress");
                });

            modelBuilder.Entity("MakerBook.Models.ProfessionalModel", b =>
                {
                    b.Property<int>("ProfessionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfessionalId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessionalId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.Property<string>("WebPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("WebPage");

                    b.HasKey("ProfessionalId");

                    b.ToTable("Professional");
                });

            modelBuilder.Entity("MakerBook.Models.ProfessionalProfileModel", b =>
                {
                    b.Property<int>("ProfessionalProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfessionalProfileId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessionalProfileId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<byte[]>("ImageProfile")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("ImageProfile");

                    b.Property<int>("ProfessionalId")
                        .HasColumnType("int")
                        .HasColumnName("ProfessionalId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.HasKey("ProfessionalProfileId");

                    b.HasIndex("ProfessionalId");

                    b.ToTable("ProfessionalProfile");
                });

            modelBuilder.Entity("MakerBook.Models.ProfessionalSocialMediaModel", b =>
                {
                    b.Property<int>("ProfessionalSocialMediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfessionalSocialMediaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessionalSocialMediaId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<int>("ProfessionalProfileId")
                        .HasColumnType("int")
                        .HasColumnName("ProfessionalProfileId");

                    b.Property<int>("ProfessionalProfileType")
                        .HasColumnType("int")
                        .HasColumnName("ProfessionalProfileType");

                    b.Property<string>("SocialMedia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SocialMedia");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.HasKey("ProfessionalSocialMediaId");

                    b.HasIndex("ProfessionalProfileId");

                    b.ToTable("ProfessionalSocialMedia");
                });

            modelBuilder.Entity("MakerBook.Models.ServiceAddressModel", b =>
                {
                    b.Property<int>("ServiceAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceAddressId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceAddressId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

                    b.Property<string>("ComplementAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ComplementAddress");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Country");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<double>("Latitude")
                        .HasColumnType("float")
                        .HasColumnName("Latitude");

                    b.Property<string>("LineAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LineAddress");

                    b.Property<double>("Longitude")
                        .HasColumnType("float")
                        .HasColumnName("Longitude");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("ServiceId");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("State");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ZipCode");

                    b.HasKey("ServiceAddressId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceAddress");
                });

            modelBuilder.Entity("MakerBook.Models.ServiceImageModel", b =>
                {
                    b.Property<int>("ServiceImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceImageId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceImageId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("ServiceId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.HasKey("ServiceImageId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceImage");
                });

            modelBuilder.Entity("MakerBook.Models.ServiceModel", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Price");

                    b.Property<int>("ProfessionalId")
                        .HasColumnType("int")
                        .HasColumnName("ProfessionalId");

                    b.Property<int>("ServiceType")
                        .HasColumnType("int")
                        .HasColumnName("ServiceType");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.HasKey("ServiceId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProfessionalId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("MakerBook.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<int>("Profile")
                        .HasColumnType("int")
                        .HasColumnName("Profile");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAt");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MakerBook.Models.OrderModel", b =>
                {
                    b.HasOne("MakerBook.Models.CustomerModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakerBook.Models.ServiceModel", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("MakerBook.Models.ProfessionalAddressModel", b =>
                {
                    b.HasOne("MakerBook.Models.ProfessionalModel", "Professional")
                        .WithMany()
                        .HasForeignKey("ProfessionalId");

                    b.Navigation("Professional");
                });

            modelBuilder.Entity("MakerBook.Models.ProfessionalProfileModel", b =>
                {
                    b.HasOne("MakerBook.Models.ProfessionalModel", "Professional")
                        .WithMany()
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professional");
                });

            modelBuilder.Entity("MakerBook.Models.ProfessionalSocialMediaModel", b =>
                {
                    b.HasOne("MakerBook.Models.ProfessionalProfileModel", "ProfessionalProfile")
                        .WithMany()
                        .HasForeignKey("ProfessionalProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfessionalProfile");
                });

            modelBuilder.Entity("MakerBook.Models.ServiceAddressModel", b =>
                {
                    b.HasOne("MakerBook.Models.ServiceModel", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("MakerBook.Models.ServiceImageModel", b =>
                {
                    b.HasOne("MakerBook.Models.ServiceModel", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("MakerBook.Models.ServiceModel", b =>
                {
                    b.HasOne("MakerBook.Models.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakerBook.Models.ProfessionalModel", "Professional")
                        .WithMany()
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Professional");
                });
#pragma warning restore 612, 618
        }
    }
}
