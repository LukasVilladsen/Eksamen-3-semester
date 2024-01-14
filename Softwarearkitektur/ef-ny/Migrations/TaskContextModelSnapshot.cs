﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ef_trello.Model;

#nullable disable

namespace _44.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("ef_trello.Model.Todo", b =>
                {
                    b.Property<long>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<long?>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoId");

                    b.HasIndex("userId");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("ef_trello.Model.User", b =>
                {
                    b.Property<long>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("userId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ef_trello.Model.Todo", b =>
                {
                    b.HasOne("ef_trello.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
