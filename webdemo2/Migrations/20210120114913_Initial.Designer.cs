﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webdemo2.Data;

namespace webdemo2.Migrations
{
    [DbContext(typeof(CarContext))]
    [Migration("20210120114913_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("webdemo2.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxSpeed")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("webdemo2.CarRegister", b =>
                {
                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("CarID", "PersonID");

                    b.HasIndex("PersonID");

                    b.ToTable("Carregister");
                });

            modelBuilder.Entity("webdemo2.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("webdemo2.CarRegister", b =>
                {
                    b.HasOne("webdemo2.Car", "Car")
                        .WithMany("RegistryEntries")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webdemo2.Person", "Person")
                        .WithMany("RegistryEntries")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("webdemo2.Car", b =>
                {
                    b.Navigation("RegistryEntries");
                });

            modelBuilder.Entity("webdemo2.Person", b =>
                {
                    b.Navigation("RegistryEntries");
                });
#pragma warning restore 612, 618
        }
    }
}