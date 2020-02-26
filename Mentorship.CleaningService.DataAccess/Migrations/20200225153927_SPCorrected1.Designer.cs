﻿// <auto-generated />
using System;
using Mentorship.CleaningService.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mentorship.CleaningService.DataAccess.Migrations
{
    [DbContext(typeof(CleaningServiceDbContext))]
    [Migration("20200225153927_SPCorrected1")]
    partial class SPCorrected1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mentorship.CleaningService.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApartmentNumber");

                    b.Property<string>("BuildingNumber");

                    b.Property<string>("City");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("StreetName");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.ClientAddress", b =>
                {
                    b.Property<int>("ClientId");

                    b.Property<int>("AddressId");

                    b.Property<int>("Id");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("ClientId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("ClientAddresses");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.ClientsDemand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("DemandStatusName");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("ClientsDemands");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<int?>("ClientId");

                    b.Property<int?>("CompanyId");

                    b.Property<int?>("CompanyId1");

                    b.Property<int?>("ContractStatusId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ServicePlanId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CompanyId1");

                    b.HasIndex("ContractStatusId");

                    b.HasIndex("ServicePlanId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.ContractStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("StatusName");

                    b.HasKey("Id");

                    b.ToTable("ContractStatuses");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Demand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<int?>("DemandStatusId");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DemandStatusId");

                    b.ToTable("Demands");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.DemandStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("StatusName");

                    b.HasKey("Id");

                    b.ToTable("DemandStatuses");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("OfferStatusId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OfferStatusId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.OfferStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("StatusName");

                    b.HasKey("Id");

                    b.ToTable("OfferStatuses");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("RoleId");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.ServicePlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ServicePlanName");

                    b.Property<decimal>("ServicePlanValue");

                    b.HasKey("Id");

                    b.ToTable("ServicePlans");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.WorkerRole", b =>
                {
                    b.Property<int>("WorkerId");

                    b.Property<int>("RoleId");

                    b.Property<int>("Id");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("WorkerId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("WorkerRoles");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Client", b =>
                {
                    b.HasOne("Mentorship.CleaningService.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.ClientAddress", b =>
                {
                    b.HasOne("Mentorship.CleaningService.Models.Address", "Address")
                        .WithMany("ClientAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mentorship.CleaningService.Models.Client", "Client")
                        .WithMany("ClientAddresses")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Contract", b =>
                {
                    b.HasOne("Mentorship.CleaningService.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Mentorship.CleaningService.Models.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId");

                    b.HasOne("Mentorship.CleaningService.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Mentorship.CleaningService.Models.Company")
                        .WithMany("Contracts")
                        .HasForeignKey("CompanyId1");

                    b.HasOne("Mentorship.CleaningService.Models.ContractStatus", "ContractStatus")
                        .WithMany()
                        .HasForeignKey("ContractStatusId");

                    b.HasOne("Mentorship.CleaningService.Models.ServicePlan", "ServicePlan")
                        .WithMany()
                        .HasForeignKey("ServicePlanId");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Demand", b =>
                {
                    b.HasOne("Mentorship.CleaningService.Models.Client", "Client")
                        .WithMany("Demands")
                        .HasForeignKey("ClientId");

                    b.HasOne("Mentorship.CleaningService.Models.DemandStatus", "DemandStatus")
                        .WithMany()
                        .HasForeignKey("DemandStatusId");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Offer", b =>
                {
                    b.HasOne("Mentorship.CleaningService.Models.Company", "Company")
                        .WithMany("Offers")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Mentorship.CleaningService.Models.OfferStatus", "OfferStatus")
                        .WithMany()
                        .HasForeignKey("OfferStatusId");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Person", b =>
                {
                    b.HasOne("Mentorship.CleaningService.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Role", b =>
                {
                    b.HasOne("Mentorship.CleaningService.Models.Role")
                        .WithMany("Roles")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.Worker", b =>
                {
                    b.HasOne("Mentorship.CleaningService.Models.Company")
                        .WithMany("Workers")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Mentorship.CleaningService.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Mentorship.CleaningService.Models.Worker")
                        .WithMany("Workers")
                        .HasForeignKey("WorkerId");
                });

            modelBuilder.Entity("Mentorship.CleaningService.Models.WorkerRole", b =>
                {
                    b.HasOne("Mentorship.CleaningService.Models.Role", "Role")
                        .WithMany("WorkerRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mentorship.CleaningService.Models.Worker", "Worker")
                        .WithMany("WorkerRoles")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
