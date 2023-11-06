﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Infrastructure;

#nullable disable

namespace TodoList.Infrastructure.Migrations
{
    [DbContext(typeof(TodoListContext))]
    partial class TodoListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TodoList.Core.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoleId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("TodoList.Core.TodoTask", b =>
                {
                    b.Property<int>("TodoTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Completed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TodoTaskId");

                    b.HasIndex("UserId");

                    b.ToTable("TodoTasks");

                    b.HasData(
                        new
                        {
                            TodoTaskId = 1,
                            Completed = false,
                            Description = "Hacer tarea 1",
                            UserId = 1
                        },
                        new
                        {
                            TodoTaskId = 2,
                            Completed = true,
                            Description = "Hacer tarea 2",
                            UserId = 1
                        },
                        new
                        {
                            TodoTaskId = 3,
                            Completed = false,
                            Description = "Hacer tarea 3",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("TodoList.Core.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "1234",
                            RoleId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "juferpassword",
                            RoleId = 2,
                            Username = "jufergom"
                        });
                });

            modelBuilder.Entity("TodoList.Core.TodoTask", b =>
                {
                    b.HasOne("TodoList.Core.User", "User")
                        .WithMany("TodoTasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TodoList.Core.User", b =>
                {
                    b.HasOne("TodoList.Core.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TodoList.Core.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TodoList.Core.User", b =>
                {
                    b.Navigation("TodoTasks");
                });
#pragma warning restore 612, 618
        }
    }
}