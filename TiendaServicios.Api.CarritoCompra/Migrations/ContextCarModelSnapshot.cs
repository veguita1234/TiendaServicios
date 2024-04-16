﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaServicios.Api.CarritoCompra.Persistence;

#nullable disable

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    [DbContext(typeof(ContextCar))]
    partial class ContextCarModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Model.CarSession", b =>
                {
                    b.Property<int>("CarSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CarSessionId");

                    b.ToTable("CarSession");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Model.CarSessionDetail", b =>
                {
                    b.Property<int>("CarSessionDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarSessionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SelectedProduct")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CarSessionDetailId");

                    b.HasIndex("CarSessionId");

                    b.ToTable("CarSessionDetail");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Model.CarSessionDetail", b =>
                {
                    b.HasOne("TiendaServicios.Api.CarritoCompra.Model.CarSession", "CarSession")
                        .WithMany("ListDetail")
                        .HasForeignKey("CarSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarSession");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Model.CarSession", b =>
                {
                    b.Navigation("ListDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
