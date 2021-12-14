﻿// <auto-generated />
using System;
using Infrastructure.DataAccess.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(IssueTrackerContext))]
    partial class IssueTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Issue", b =>
                {
                    b.Property<Guid>("IssueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssignedTo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IssueId");

                    b.ToTable("Issue", (string)null);

                    b.HasData(
                        new
                        {
                            IssueId = new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890"),
                            AssignedTo = new Guid("00000000-0000-0000-0000-000000000000"),
                            Description = "description1",
                            Points = 1,
                            Status = "0",
                            Title = "issue1"
                        },
                        new
                        {
                            IssueId = new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298"),
                            AssignedTo = new Guid("c571342a-74f3-4c60-b39a-4b7625aea957"),
                            Description = "description2",
                            Points = 2,
                            Status = "0",
                            Title = "issue2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
