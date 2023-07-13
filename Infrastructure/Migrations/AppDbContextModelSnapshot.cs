﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.AccountManagerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountManagers");
                });

            modelBuilder.Entity("Infrastructure.Entities.CustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountManagerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountManagerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Infrastructure.Entities.CustomerPhoneModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerPhones");
                });

            modelBuilder.Entity("Infrastructure.Entities.ProjectModel", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("AccountManagerId")
                        .HasColumnType("int");

                    b.Property<int>("SmmManagerId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId", "AccountManagerId", "SmmManagerId", "Id");

                    b.HasIndex("AccountManagerId");

                    b.HasIndex("SmmManagerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Infrastructure.Entities.SmmManagerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SmmManagers");
                });

            modelBuilder.Entity("Infrastructure.Entities.CustomerModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.AccountManagerModel", "AccountManager")
                        .WithMany()
                        .HasForeignKey("AccountManagerId");

                    b.Navigation("AccountManager");
                });

            modelBuilder.Entity("Infrastructure.Entities.CustomerPhoneModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.CustomerModel", "Customer")
                        .WithMany("CustomerPhones")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Infrastructure.Entities.ProjectModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.AccountManagerModel", "AccountManager")
                        .WithMany("Projects")
                        .HasForeignKey("AccountManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.CustomerModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.SmmManagerModel", "SmmManager")
                        .WithMany("Projects")
                        .HasForeignKey("SmmManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountManager");

                    b.Navigation("Customer");

                    b.Navigation("SmmManager");
                });

            modelBuilder.Entity("Infrastructure.Entities.AccountManagerModel", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Infrastructure.Entities.CustomerModel", b =>
                {
                    b.Navigation("CustomerPhones");
                });

            modelBuilder.Entity("Infrastructure.Entities.SmmManagerModel", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
