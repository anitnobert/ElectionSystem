﻿// <auto-generated />
using ElectionCommission.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectionCommission.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240120111820_Inisdfsdfsdf")]
    partial class Inisdfsdfsdf
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("ElectionCommission.Models.Commissioner", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecretToken")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Officials", (string)null);
                });

            modelBuilder.Entity("ElectionCommission.Models.Constituency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StateId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Constituency", (string)null);
                });

            modelBuilder.Entity("ElectionCommission.Models.Party", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Party", (string)null);
                });

            modelBuilder.Entity("ElectionCommission.Models.StateDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("States", (string)null);
                });

            modelBuilder.Entity("ElectionCommission.Models.Voter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Approved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Voters", (string)null);
                });

            modelBuilder.Entity("ElectionCommission.Models.Constituency", b =>
                {
                    b.HasOne("ElectionCommission.Models.StateDetail", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
