﻿// <auto-generated />
using System;
using AirStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250321114420_nig5")]
    partial class nig5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirStore.Models.Characteristic", b =>
                {
                    b.Property<int?>("IdCharacteristic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdCharacteristic"));

                    b.Property<string>("CharName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCharacteristic");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("AirStore.Models.ProdCharacter", b =>
                {
                    b.Property<int?>("IdProdCharacter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdProdCharacter"));

                    b.Property<int?>("IdCharacteristic")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.HasKey("IdProdCharacter");

                    b.HasIndex("IdCharacteristic");

                    b.HasIndex("IdProduct");

                    b.ToTable("ProdCharacters");
                });

            modelBuilder.Entity("AirStore.Models.Product", b =>
                {
                    b.Property<int?>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdProduct"));

                    b.Property<string>("Diskription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("IdProduct");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AirStore.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRole"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdRole");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AirStore.Models.SuperBusket", b =>
                {
                    b.Property<int?>("IdSuperBasket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdSuperBasket"));

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int");

                    b.Property<bool?>("Visibility")
                        .HasColumnType("bit");

                    b.HasKey("IdSuperBasket");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdUser");

                    b.ToTable("SuperBuskets");
                });

            modelBuilder.Entity("AirStore.Models.User", b =>
                {
                    b.Property<int?>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdUser"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.HasIndex("IdRole");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AirStore.Models.ProdCharacter", b =>
                {
                    b.HasOne("AirStore.Models.Characteristic", "Characteristic")
                        .WithMany("ProdCharacters")
                        .HasForeignKey("IdCharacteristic");

                    b.HasOne("AirStore.Models.Product", "Product")
                        .WithMany("ProdCharacters")
                        .HasForeignKey("IdProduct");

                    b.Navigation("Characteristic");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AirStore.Models.SuperBusket", b =>
                {
                    b.HasOne("AirStore.Models.Product", "Product")
                        .WithMany("SuperBuskets")
                        .HasForeignKey("IdProduct");

                    b.HasOne("AirStore.Models.User", "User")
                        .WithMany("SuperBuskets")
                        .HasForeignKey("IdUser");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AirStore.Models.User", b =>
                {
                    b.HasOne("AirStore.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("IdRole");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AirStore.Models.Characteristic", b =>
                {
                    b.Navigation("ProdCharacters");
                });

            modelBuilder.Entity("AirStore.Models.Product", b =>
                {
                    b.Navigation("ProdCharacters");

                    b.Navigation("SuperBuskets");
                });

            modelBuilder.Entity("AirStore.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AirStore.Models.User", b =>
                {
                    b.Navigation("SuperBuskets");
                });
#pragma warning restore 612, 618
        }
    }
}
