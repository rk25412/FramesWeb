﻿// <auto-generated />
using System;
using Frames.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Frames.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250104105613_AddedBillingTables")]
    partial class AddedBillingTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Frames.Entities.Billing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Month")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Billing");
                });

            modelBuilder.Entity("Frames.Entities.BillingItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BillingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BillingId");

                    b.ToTable("BillingItem");
                });

            modelBuilder.Entity("Frames.Entities.BillingItemDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BillingItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BillingItemId");

                    b.ToTable("BillingItemDetail");
                });

            modelBuilder.Entity("Frames.Entities.BillingSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BillingId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("LastMonth")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPaid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BillingId");

                    b.ToTable("BillingSummary");
                });

            modelBuilder.Entity("Frames.Entities.FrameType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MasterFrameRate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("WorkerFrameRate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FrameTypes");
                });

            modelBuilder.Entity("Frames.Entities.MasterFrameIn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("FrameCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MasterFrameIns");
                });

            modelBuilder.Entity("Frames.Entities.MasterFrameOut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MasterFrameOuts");
                });

            modelBuilder.Entity("Frames.Entities.MasterFrameOutType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("FrameRate")
                        .HasColumnType("TEXT");

                    b.Property<int>("FrameTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MasterFrameOutId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FrameTypeId");

                    b.HasIndex("MasterFrameOutId");

                    b.ToTable("MasterFrameOutTypes");
                });

            modelBuilder.Entity("Frames.Entities.Paid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("BillingId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BillingId");

                    b.ToTable("Paid");
                });

            modelBuilder.Entity("Frames.Entities.Payments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Frames.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Frames.Entities.WorkerFrameIn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("NoOfFrames")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerFrameIns");
                });

            modelBuilder.Entity("Frames.Entities.WorkerFrameOut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerFrameOuts");
                });

            modelBuilder.Entity("Frames.Entities.WorkerFrameOutType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FrameCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FrameOutId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("FrameRate")
                        .HasColumnType("TEXT");

                    b.Property<int>("FrameTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FrameOutId");

                    b.HasIndex("FrameTypeId");

                    b.ToTable("WorkerFrameOutTypes");
                });

            modelBuilder.Entity("Frames.Entities.BillingItem", b =>
                {
                    b.HasOne("Frames.Entities.Billing", "Billing")
                        .WithMany("BillingItems")
                        .HasForeignKey("BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Frames.Entities.BillingItemDetail", b =>
                {
                    b.HasOne("Frames.Entities.BillingItem", "BillingItem")
                        .WithMany("BillingItemDetails")
                        .HasForeignKey("BillingItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BillingItem");
                });

            modelBuilder.Entity("Frames.Entities.BillingSummary", b =>
                {
                    b.HasOne("Frames.Entities.Billing", "Billing")
                        .WithMany()
                        .HasForeignKey("BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Frames.Entities.MasterFrameOutType", b =>
                {
                    b.HasOne("Frames.Entities.FrameType", "FrameType")
                        .WithMany()
                        .HasForeignKey("FrameTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Frames.Entities.MasterFrameOut", "MasterFrameOut")
                        .WithMany("MasterFrameOutTypes")
                        .HasForeignKey("MasterFrameOutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FrameType");

                    b.Navigation("MasterFrameOut");
                });

            modelBuilder.Entity("Frames.Entities.Paid", b =>
                {
                    b.HasOne("Frames.Entities.Billing", "Billing")
                        .WithMany("Paid")
                        .HasForeignKey("BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Frames.Entities.WorkerFrameIn", b =>
                {
                    b.HasOne("Frames.Entities.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Frames.Entities.WorkerFrameOut", b =>
                {
                    b.HasOne("Frames.Entities.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Frames.Entities.WorkerFrameOutType", b =>
                {
                    b.HasOne("Frames.Entities.WorkerFrameOut", "WorkerFrameOut")
                        .WithMany("WorkerFrameOutTypes")
                        .HasForeignKey("FrameOutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Frames.Entities.FrameType", "FrameType")
                        .WithMany()
                        .HasForeignKey("FrameTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FrameType");

                    b.Navigation("WorkerFrameOut");
                });

            modelBuilder.Entity("Frames.Entities.Billing", b =>
                {
                    b.Navigation("BillingItems");

                    b.Navigation("Paid");
                });

            modelBuilder.Entity("Frames.Entities.BillingItem", b =>
                {
                    b.Navigation("BillingItemDetails");
                });

            modelBuilder.Entity("Frames.Entities.MasterFrameOut", b =>
                {
                    b.Navigation("MasterFrameOutTypes");
                });

            modelBuilder.Entity("Frames.Entities.WorkerFrameOut", b =>
                {
                    b.Navigation("WorkerFrameOutTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
