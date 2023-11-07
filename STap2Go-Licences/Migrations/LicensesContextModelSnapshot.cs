﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using STap2Go_Licenses.Context;

#nullable disable

namespace STap2Go_Licenses.Migrations
{
    [DbContext(typeof(LicensesContext))]
    partial class LicensesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("STap2Go_Licenses.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdCliente");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Direccion1");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Direccion2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Ciudad");

                    b.Property<string>("CompanyNIF")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NIFEmpresa");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NombreEmpresa");

                    b.Property<string>("ContactNIF")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NIFContacto");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Pais");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("EmailCliente");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NombreContacto");

                    b.Property<bool>("IsCompany")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("EsEmpresa");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ApellidoContacto");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CodigoPostal");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Provincia");

                    b.HasKey("Id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("STap2Go_Licenses.Entities.License", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdLicencia");

                    b.Property<DateTime?>("AssignmentDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("FechaAsignacion");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("IdCliente");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("LicenseCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Licencia");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Estado");

                    b.Property<DateTime?>("UsageDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("FechaUso");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("licenciastest");
                });

            modelBuilder.Entity("STap2Go_Licenses.Entities.License", b =>
                {
                    b.HasOne("STap2Go_Licenses.Entities.Client", "Client")
                        .WithMany("Licenses")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("STap2Go_Licenses.Entities.Client", b =>
                {
                    b.Navigation("Licenses");
                });
#pragma warning restore 612, 618
        }
    }
}
