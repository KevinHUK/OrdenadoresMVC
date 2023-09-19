﻿// <auto-generated />
using System;
using MVC_ComponentesCodeFirst.App_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_ComponentesCodeFirst.Migrations
{
    [DbContext(typeof(ComponentesCodeFirstContext))]
    [Migration("20230824094455_MigracionPedidos")]
    partial class MigracionPedidos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Componente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<int?>("Cores")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Grados")
                        .HasColumnType("int");

                    b.Property<long?>("Megas")
                        .HasColumnType("bigint");

                    b.Property<string>("NumeroDeSerie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("OrdenadorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrdenadorId");

                    b.ToTable("Componentes");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Ordenador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CalorTotal")
                        .HasColumnType("int");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Propietario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Ordenadores");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrdenadorId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Temperatura")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Componente", b =>
                {
                    b.HasOne("MVC_ComponentesCodeFirst.Models.Ordenador", null)
                        .WithMany("Componentes")
                        .HasForeignKey("OrdenadorId");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Ordenador", b =>
                {
                    b.HasOne("MVC_ComponentesCodeFirst.Models.Pedido", null)
                        .WithMany("Ordenadores")
                        .HasForeignKey("PedidoId");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Ordenador", b =>
                {
                    b.Navigation("Componentes");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Pedido", b =>
                {
                    b.Navigation("Ordenadores");
                });
#pragma warning restore 612, 618
        }
    }
}