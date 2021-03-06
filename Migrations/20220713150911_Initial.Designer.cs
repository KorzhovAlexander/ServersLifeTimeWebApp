// <auto-generated />
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
    [Migration("20220713150911_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ServersLifeTimeWebApp.Data.Server", b =>
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
                });
#pragma warning restore 612, 618
        }
    }
}
