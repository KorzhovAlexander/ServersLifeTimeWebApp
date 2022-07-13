﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServersLifeTimeWebApp.Data;

#nullable disable

namespace ServersLifeTimeWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220713152907_Default data")]
    partial class Defaultdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ServersLifeTimeWebApp.Data.Entity.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDateTime");

                    b.Property<bool>("IsSelectedForRemove")
                        .HasColumnType("bit")
                        .HasColumnName("SelectedForRemove");

                    b.Property<DateTime?>("RemoveDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RemoveDateTime");

                    b.HasKey("Id")
                        .HasName("VirtualServerId");

                    b.ToTable("Servers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2019, 1, 21, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsSelectedForRemove = false,
                            RemoveDate = new DateTime(2019, 1, 21, 16, 40, 35, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2019, 1, 21, 12, 40, 0, 0, DateTimeKind.Unspecified),
                            IsSelectedForRemove = false,
                            RemoveDate = new DateTime(2019, 1, 21, 16, 40, 35, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}