﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TFM104MVC.Models;

namespace TFM104MVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
    [Migration("20220408050644_orderMigration")]
    partial class orderMigration
=======
    [Migration("20220405111949_PIC")]
    partial class PIC
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TFM104MVC.Models.Admin", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Admins");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.Firm", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");
=======
            modelBuilder.Entity("TFM104MVC.Models.CustomerRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("CustomerRatings");
                });

            modelBuilder.Entity("TFM104MVC.Models.Firm", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Firms");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.LineItem", b =>
                {
=======
            modelBuilder.Entity("TFM104MVC.Models.Member", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("PicPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("TFM104MVC.Models.Order", b =>
                {
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
=======

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.Property<double?>("DiscountPersent")
                        .HasColumnType("float");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");
=======
                    b.Property<int>("UserId")
                        .HasColumnType("int");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("LineItems");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.Member", b =>
                {
                    b.Property<int>("UserId")
=======
            modelBuilder.Entity("TFM104MVC.Models.Orderdetail", b =>
                {
                    b.Property<int>("OrderId")
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("PicPath")
                        .HasColumnType("nvarchar(max)");

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
                    b.HasKey("UserId");
=======
                    b.Property<int>("RateId")
                        .HasColumnType("int");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.ToTable("Members");
                });

            modelBuilder.Entity("TFM104MVC.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("TransactionMetaData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
                    b.ToTable("Orders");
=======
                    b.ToTable("Orderdetails");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                });

            modelBuilder.Entity("TFM104MVC.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("CustomerRating")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<double?>("DiscountPersent")
                        .HasColumnType("float");

                    b.Property<DateTime?>("GoTouristTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Region")
                        .HasColumnType("int");

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");
=======
                    b.Property<int?>("Region")
                        .HasColumnType("int");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TravelDays")
                        .HasColumnType("int");

                    b.Property<int?>("TripType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TFM104MVC.Models.ProductPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");
=======
                        .HasColumnType("nvarchar(max)");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPictures");
                });

            modelBuilder.Entity("TFM104MVC.Models.Role", b =>
<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TFM104MVC.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");
=======
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Name");

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ShoppingCarts");
=======
                    b.ToTable("Roles");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                });

            modelBuilder.Entity("TFM104MVC.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
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

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(450)");
<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");
=======
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.Property<bool>("Verification")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RoleName");
<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TFM104MVC.Models.Admin", b =>
                {
                    b.HasOne("TFM104MVC.Models.User", "User")
                        .WithOne("Admins")
                        .HasForeignKey("TFM104MVC.Models.Admin", "UserId")
=======

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TFM104MVC.Models.Admin", b =>
                {
                    b.HasOne("TFM104MVC.Models.User", "User")
                        .WithOne("Admins")
                        .HasForeignKey("TFM104MVC.Models.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TFM104MVC.Models.CustomerRating", b =>
                {
                    b.HasOne("TFM104MVC.Models.Product", "Product")
                        .WithMany("CustomerRatings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TFM104MVC.Models.Firm", b =>
                {
                    b.HasOne("TFM104MVC.Models.User", "User")
                        .WithOne("Firms")
                        .HasForeignKey("TFM104MVC.Models.Firm", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TFM104MVC.Models.Member", b =>
                {
                    b.HasOne("TFM104MVC.Models.User", "User")
                        .WithOne("Members")
                        .HasForeignKey("TFM104MVC.Models.Member", "UserId")
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.Firm", b =>
                {
                    b.HasOne("TFM104MVC.Models.User", "User")
                        .WithOne("Firms")
                        .HasForeignKey("TFM104MVC.Models.Firm", "UserId")
=======
            modelBuilder.Entity("TFM104MVC.Models.Order", b =>
                {
                    b.HasOne("TFM104MVC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.LineItem", b =>
                {
                    b.HasOne("TFM104MVC.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("TFM104MVC.Models.Product", "Product")
                        .WithMany()
=======
            modelBuilder.Entity("TFM104MVC.Models.Orderdetail", b =>
                {
                    b.HasOne("TFM104MVC.Models.Order", "Order")
                        .WithMany("Orderdetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFM104MVC.Models.Product", "Product")
                        .WithMany("Orderdetails")
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
                    b.HasOne("TFM104MVC.Models.ShoppingCart", null)
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ShoppingCartId");
=======
                    b.HasOne("TFM104MVC.Models.CustomerRating", "CustomerRating")
                        .WithOne("Orderdetail")
                        .HasForeignKey("TFM104MVC.Models.Orderdetail", "RateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerRating");

                    b.Navigation("Order");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.Navigation("Product");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.Member", b =>
                {
                    b.HasOne("TFM104MVC.Models.User", "User")
                        .WithOne("Members")
                        .HasForeignKey("TFM104MVC.Models.Member", "UserId")
=======
            modelBuilder.Entity("TFM104MVC.Models.ProductPicture", b =>
                {
                    b.HasOne("TFM104MVC.Models.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductId")
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.Order", b =>
                {
                    b.HasOne("TFM104MVC.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
=======
            modelBuilder.Entity("TFM104MVC.Models.User", b =>
                {
                    b.HasOne("TFM104MVC.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleName");
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs

                    b.Navigation("User");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.ProductPicture", b =>
                {
                    b.HasOne("TFM104MVC.Models.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TFM104MVC.Models.ShoppingCart", b =>
                {
                    b.HasOne("TFM104MVC.Models.User", "User")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("TFM104MVC.Models.ShoppingCart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TFM104MVC.Models.User", b =>
=======
            modelBuilder.Entity("TFM104MVC.Models.CustomerRating", b =>
                {
                    b.Navigation("Orderdetail");
                });

            modelBuilder.Entity("TFM104MVC.Models.Order", b =>
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                {
                    b.HasOne("TFM104MVC.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleName");

                    b.Navigation("Role");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.Order", b =>
=======
            modelBuilder.Entity("TFM104MVC.Models.Product", b =>
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("TFM104MVC.Models.Product", b =>
                {
                    b.Navigation("ProductPictures");
                });

<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs
            modelBuilder.Entity("TFM104MVC.Models.ShoppingCart", b =>
=======
            modelBuilder.Entity("TFM104MVC.Models.Role", b =>
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                {
                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("TFM104MVC.Models.User", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Firms");

                    b.Navigation("Members");
<<<<<<< HEAD:TFM104MVC/TFM104MVC/Migrations/20220408050644_orderMigration.Designer.cs

                    b.Navigation("Orders");

                    b.Navigation("ShoppingCart");
=======
>>>>>>> unity1:TFM104MVC/TFM104MVC/Migrations/20220405111949_PIC.Designer.cs
                });
#pragma warning restore 612, 618
        }
    }
}
