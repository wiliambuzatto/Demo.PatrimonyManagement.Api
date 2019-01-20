﻿// <auto-generated />
using System;
using Demo.PatrimonyManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.PatrimonyManagement.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190120155039_AlterTable_User")]
    partial class AlterTable_User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Demo.PatrimonyManagement.Domain.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Demo.PatrimonyManagement.Domain.LogEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationDate");

                    b.Property<Guid>("EntityId");

                    b.Property<string>("EntityName");

                    b.Property<DateTime>("LogDateTime");

                    b.Property<string>("Operation");

                    b.Property<Guid?>("UserId");

                    b.Property<string>("ValuesChanges");

                    b.HasKey("Id");

                    b.ToTable("LogEntry");
                });

            modelBuilder.Entity("Demo.PatrimonyManagement.Domain.Patrimony", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BrandId");

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(100);

                    b.Property<Guid>("TippingNumber")
                        .HasColumnType("uniqueIdentifier")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Patrimony");
                });

            modelBuilder.Entity("Demo.PatrimonyManagement.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Demo.PatrimonyManagement.Domain.Patrimony", b =>
                {
                    b.HasOne("Demo.PatrimonyManagement.Domain.Brand", "Brand")
                        .WithMany("Patrimonies")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
