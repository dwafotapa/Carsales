using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Carsales.Core.Domain;

namespace Carsales.Web.Migrations
{
    [DbContext(typeof(CarsalesContext))]
    [Migration("20170503121845_CreateTablesMigration")]
    partial class CreateTablesMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Carsales.Core.Domain.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .IsRequired();

                    b.Property<string>("ContactName");

                    b.Property<decimal?>("DapPrice");

                    b.Property<string>("DealerABN");

                    b.Property<decimal?>("EgcPrice");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<int>("PriceType")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Carsales.Core.Domain.Enquiry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CarId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Enquiry");
                });

            modelBuilder.Entity("Carsales.Core.Domain.Enquiry", b =>
                {
                    b.HasOne("Carsales.Core.Domain.Car", "Car")
                        .WithMany("Enquiries")
                        .HasForeignKey("CarId");
                });
        }
    }
}
