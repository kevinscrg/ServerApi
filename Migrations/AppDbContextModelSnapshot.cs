﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerApi.Data;

#nullable disable

namespace ServerApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("CarteGen", b =>
                {
                    b.Property<int>("CartiId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenuriId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartiId", "GenuriId");

                    b.HasIndex("GenuriId");

                    b.ToTable("CarteGen", (string)null);
                });

            modelBuilder.Entity("CarteTrope", b =>
                {
                    b.Property<int>("CartiId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TropeuriId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartiId", "TropeuriId");

                    b.HasIndex("TropeuriId");

                    b.ToTable("CarteTrope");
                });

            modelBuilder.Entity("ServerApi.Models.Carte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DataAparitie")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<int>("NrPagini")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Poza")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Pret")
                        .HasColumnType("REAL");

                    b.Property<float?>("Rating")
                        .HasColumnType("REAL");

                    b.Property<string>("Titlu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Carti");
                });

            modelBuilder.Entity("ServerApi.Models.Gen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nume")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genuri");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nume = "Thriller"
                        },
                        new
                        {
                            Id = 2,
                            Nume = "Romance"
                        },
                        new
                        {
                            Id = 3,
                            Nume = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            Nume = "Politist"
                        });
                });

            modelBuilder.Entity("ServerApi.Models.Recenzie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CarteId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Rating")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CarteId");

                    b.HasIndex("UserId");

                    b.ToTable("Recenzii");
                });

            modelBuilder.Entity("ServerApi.Models.Trope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nume")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tropeuri");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nume = "enemies to lovers"
                        },
                        new
                        {
                            Id = 2,
                            Nume = "so many lies"
                        },
                        new
                        {
                            Id = 3,
                            Nume = "twist ending"
                        },
                        new
                        {
                            Id = 4,
                            Nume = "undercover mission"
                        });
                });

            modelBuilder.Entity("ServerApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nume")
                        .HasColumnType("TEXT");

                    b.Property<string>("Parola")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarteGen", b =>
                {
                    b.HasOne("ServerApi.Models.Carte", null)
                        .WithMany()
                        .HasForeignKey("CartiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServerApi.Models.Gen", null)
                        .WithMany()
                        .HasForeignKey("GenuriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarteTrope", b =>
                {
                    b.HasOne("ServerApi.Models.Carte", null)
                        .WithMany()
                        .HasForeignKey("CartiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServerApi.Models.Trope", null)
                        .WithMany()
                        .HasForeignKey("TropeuriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServerApi.Models.Recenzie", b =>
                {
                    b.HasOne("ServerApi.Models.Carte", null)
                        .WithMany("Recenzii")
                        .HasForeignKey("CarteId");

                    b.HasOne("ServerApi.Models.User", null)
                        .WithMany("Recenzii")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ServerApi.Models.Carte", b =>
                {
                    b.Navigation("Recenzii");
                });

            modelBuilder.Entity("ServerApi.Models.User", b =>
                {
                    b.Navigation("Recenzii");
                });
#pragma warning restore 612, 618
        }
    }
}
