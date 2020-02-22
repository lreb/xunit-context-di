﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCoreXunit.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetCoreXunit.Migrations
{
    [DbContext(typeof(NetCoreXunitContext))]
    [Migration("20200222151833_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NetCoreXunit.Data.Value", b =>
                {
                    b.Property<long>("ValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("value_id");

                    b.Property<string>("Content")
                        .HasColumnName("content");

                    b.HasKey("ValueId")
                        .HasName("pk_value");

                    b.ToTable("value");
                });
#pragma warning restore 612, 618
        }
    }
}