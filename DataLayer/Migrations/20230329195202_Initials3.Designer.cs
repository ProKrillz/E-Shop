﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    [Migration("20230329195202_Initials3")]
    partial class Initials3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategorysCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.HasKey("CategorysCategoryId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("brand_name");

                    b.HasKey("BrandId")
                        .HasName("brand_id");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId")
                        .HasName("category_id");

                    b.ToTable("Categorys", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryId"));

                    b.Property<string>("DeliveryOption")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("delivery_option");

                    b.HasKey("DeliveryId");

                    b.ToTable("Deliverys", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<int>("Fk_ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_path");

                    b.HasKey("ImageId")
                        .HasName("image_id");

                    b.HasIndex("Fk_ProductId")
                        .IsUnique();

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.Ordre", b =>
                {
                    b.Property<int>("OrdreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(10000)
                        .HasColumnName("ordre_id");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("ordre_created")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Fk_DeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("Fk_PayementId")
                        .HasColumnType("int");

                    b.Property<Guid>("Fk_UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2")
                        .HasColumnName("ordre_updated");

                    b.HasKey("OrdreId");

                    b.HasIndex("Fk_DeliveryId");

                    b.HasIndex("Fk_PayementId");

                    b.HasIndex("Fk_UserId");

                    b.ToTable("Ordres", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.OrdreProduct", b =>
                {
                    b.Property<int>("Fk_OrdreId")
                        .HasColumnType("int");

                    b.Property<int>("Fk_ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("ordre_product_amount");

                    b.HasKey("Fk_OrdreId", "Fk_ProductId");

                    b.HasIndex("Fk_ProductId");

                    b.ToTable("OrdreProduct", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<string>("PaymentOption")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("payment_option");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(100)
                        .HasColumnName("product_id");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("product_description");

                    b.Property<int>("Fk_BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("product_name");

                    b.Property<decimal>("Price")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("product_price");

                    b.HasKey("ProductId");

                    b.HasIndex("Fk_BrandId");

                    b.HasIndex("Name");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("user_address");

                    b.Property<bool>("Disable")
                        .HasColumnType("bit")
                        .HasColumnName("user_disable");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("user_email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("user_firstname");

                    b.Property<int>("Fk_ZipCodeId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("user_lastname");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_password");

                    b.HasKey("UserId")
                        .HasName("user_id");

                    b.HasIndex("Fk_ZipCodeId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.ZipCode", b =>
                {
                    b.Property<int>("ZipCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("zipcode_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZipCodeId"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("zipcode_city");

                    b.HasKey("ZipCodeId");

                    b.ToTable("ZipCodes", (string)null);
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("DataLayer.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategorysCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.Image", b =>
                {
                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithOne("Image")
                        .HasForeignKey("DataLayer.Entities.Image", "Fk_ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataLayer.Entities.Ordre", b =>
                {
                    b.HasOne("DataLayer.Entities.Delivery", "Delivery")
                        .WithMany("Ordres")
                        .HasForeignKey("Fk_DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Payment", "Payment")
                        .WithMany("Ordes")
                        .HasForeignKey("Fk_PayementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.User", "User")
                        .WithMany("Ordres")
                        .HasForeignKey("Fk_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.OrdreProduct", b =>
                {
                    b.HasOne("DataLayer.Entities.Ordre", "Ordre")
                        .WithMany("Products")
                        .HasForeignKey("Fk_OrdreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("Ordres")
                        .HasForeignKey("Fk_ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ordre");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.HasOne("DataLayer.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("Fk_BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.HasOne("DataLayer.Entities.ZipCode", "ZipCode")
                        .WithMany("Users")
                        .HasForeignKey("Fk_ZipCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZipCode");
                });

            modelBuilder.Entity("DataLayer.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Entities.Delivery", b =>
                {
                    b.Navigation("Ordres");
                });

            modelBuilder.Entity("DataLayer.Entities.Ordre", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Entities.Payment", b =>
                {
                    b.Navigation("Ordes");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Navigation("Image");

                    b.Navigation("Ordres");
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.Navigation("Ordres");
                });

            modelBuilder.Entity("DataLayer.Entities.ZipCode", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}