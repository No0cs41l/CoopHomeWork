﻿// <auto-generated />
using System;
using Coop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Coop.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220417160308_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Coop.Models.AssortimentProduct", b =>
                {
                    b.Property<int>("AssortmentId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("AssortmentId", "ProductId");

                    b.ToTable("AssortimentProducts");
                });

            modelBuilder.Entity("Coop.Models.Assortment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ActiveFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActiveTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Assortments");
                });

            modelBuilder.Entity("Coop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EANCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Coop.Models.AssortimentProduct", b =>
                {
                    b.HasOne("Coop.Models.Assortment", "Assortment")
                        .WithMany("AssortimentProducts")
                        .HasForeignKey("AssortmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Coop.Models.Product", "Product")
                        .WithMany("AssortimentProducts")
                        .HasForeignKey("AssortmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assortment");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Coop.Models.Assortment", b =>
                {
                    b.Navigation("AssortimentProducts");
                });

            modelBuilder.Entity("Coop.Models.Product", b =>
                {
                    b.Navigation("AssortimentProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
