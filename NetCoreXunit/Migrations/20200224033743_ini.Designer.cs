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
    [Migration("20200224033743_ini")]
    partial class ini
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

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.HasKey("ValueId")
                        .HasName("pk_value");

                    b.ToTable("value");
                });

            modelBuilder.Entity("NetCoreXunit.Data.ValueProperty", b =>
                {
                    b.Property<long>("ValuePropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("value_property_id");

                    b.Property<string>("Content")
                        .HasColumnName("content");

                    b.Property<string>("Group")
                        .HasColumnName("group");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<long>("ValueId")
                        .HasColumnName("value_id");

                    b.HasKey("ValuePropertyId")
                        .HasName("pk_value_property");

                    b.HasIndex("ValueId")
                        .HasName("ix_value_property_value_id");

                    b.ToTable("value_property");
                });

            modelBuilder.Entity("NetCoreXunit.Data.ValueProperty", b =>
                {
                    b.HasOne("NetCoreXunit.Data.Value", "Value")
                        .WithMany("ValueProperties")
                        .HasForeignKey("ValueId")
                        .HasConstraintName("fk_value_property_value_value_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
