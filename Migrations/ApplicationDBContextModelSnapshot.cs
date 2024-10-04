﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.features.auth.model.RoleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateAt = new DateTime(2024, 10, 4, 16, 9, 26, 890, DateTimeKind.Utc).AddTicks(2303),
                            Name = "ADMIN",
                            UpdateAt = new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(3766)
                        },
                        new
                        {
                            Id = 2,
                            CreateAt = new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(4319),
                            Name = "USER",
                            UpdateAt = new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(4321)
                        });
                });

            modelBuilder.Entity("WebApplication1.features.auth.model.UserModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("SuccessToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.model.CoffeModel", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("createAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("Coffes");
                });

            modelBuilder.Entity("WebApplication1.model.CoffeSizeModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("CoffeSizes");

                    b.HasData(
                        new
                        {
                            id = 1,
                            createAt = new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(4794),
                            name = "S",
                            updateAt = new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(4795)
                        },
                        new
                        {
                            id = 2,
                            createAt = new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(5079),
                            name = "M",
                            updateAt = new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(5080)
                        },
                        new
                        {
                            id = 3,
                            createAt = new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(5081),
                            name = "L",
                            updateAt = new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(5081)
                        });
                });

            modelBuilder.Entity("WebApplication1.features.auth.model.UserModel", b =>
                {
                    b.HasOne("WebApplication1.features.auth.model.RoleModel", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebApplication1.features.auth.model.RoleModel", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
