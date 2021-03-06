﻿// <auto-generated />
using System;
using ReactStaterKitApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ReactStaterKitApi.Migrations
{
    [DbContext(typeof(ReactStaterKitDbContext))]
    partial class ReactStaterKitDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("ReactStaterKitApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Avatar");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, Email = "xuantuan93@gmail.com", FirstName = "Tuan", LastName = "Nguyen", Username = "Tuan" },
                        new { Id = 2, Email = "baoduy2412@outlook.com", FirstName = "Steven", LastName = "Hoang", Username = "Steven" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
