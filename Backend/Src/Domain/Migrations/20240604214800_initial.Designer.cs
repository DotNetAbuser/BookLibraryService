﻿// <auto-generated />
using System;
using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240604214800_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AuthorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2091),
                            FirstName = "Александр",
                            LastName = "Шпак",
                            MiddleName = "",
                            PicturePath = "Files//Images//AuthorPictures//1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2106),
                            FirstName = "Оксана",
                            LastName = "Сижулина",
                            MiddleName = "",
                            PicturePath = "Files//Images//AuthorPictures//2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2108),
                            FirstName = "Петр",
                            LastName = "Кировский",
                            MiddleName = "",
                            PicturePath = "Files//Images//AuthorPictures//3.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2110),
                            FirstName = "Адель",
                            LastName = "Каитская",
                            MiddleName = "",
                            PicturePath = "Files//Images//AuthorPictures//4.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2112),
                            FirstName = "Михаил",
                            LastName = "Кармов",
                            MiddleName = "",
                            PicturePath = "Files//Images//AuthorPictures//5.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2115),
                            FirstName = "Виолета",
                            LastName = "Сергеева",
                            MiddleName = "",
                            PicturePath = "Files//Images//AuthorPictures//6.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2116),
                            FirstName = "Азиз",
                            LastName = "Тураев",
                            MiddleName = "Автор",
                            PicturePath = "Files//Images//AuthorPictures//7.jpg"
                        });
                });

            modelBuilder.Entity("Domain.Entities.BookEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Domain.Entities.GenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9514),
                            Name = "Сказки"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9523),
                            Name = "Детектив"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9525),
                            Name = "Роман"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9526),
                            Name = "Комедия"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9528),
                            Name = "Драма"
                        });
                });

            modelBuilder.Entity("Domain.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TakenFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TakenTo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Entities.OrderStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(9269),
                            Name = "Ожидает получения"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(9279),
                            Name = "Взята в пользование"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(9281),
                            Name = "Ожидает возврата"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(9282),
                            Name = "Закрыта"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ReviewEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80d88135-2b4d-44b5-8bc8-45e017ddc7d5"),
                            Content = "Брал книгу в аренду на 1 месяц, после чего продлил еще на один, остался очень доволен!",
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1820),
                            Grade = 5,
                            UserId = new Guid("cdc4a3b4-125f-47f6-8a26-99d057c47d5b")
                        },
                        new
                        {
                            Id = new Guid("cd5f9608-2cba-4a48-b93d-d9decb7d0e96"),
                            Content = "Взяла на 2 недели сказку, Репка мне очень понравилась.",
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1891),
                            Grade = 5,
                            UserId = new Guid("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5")
                        },
                        new
                        {
                            Id = new Guid("c98f6c30-4bcf-412b-a0ae-dd63ff9bfbde"),
                            Content = "Брал повесть о похождениях Петра Великого очень понравился рекомендую!",
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1896),
                            Grade = 4,
                            UserId = new Guid("08278464-1115-440e-b6ab-5f70d77db79d")
                        },
                        new
                        {
                            Id = new Guid("5f48896f-07d7-49da-98a5-220ec0eb179b"),
                            Content = "Пользуюсь услугами этой организации уже 2 года очень довольна, всегда есть что взять почитать!",
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1899),
                            Grade = 5,
                            UserId = new Guid("2f25fde8-c877-407c-adc9-cad036363c53")
                        },
                        new
                        {
                            Id = new Guid("822b6229-551f-4f61-aa4f-46713557a360"),
                            Content = "Брал для учебы учебник по математике 11 класс, смогу подготовиться к ЕГЭ и сдал его на 82 балла, очень благодарен",
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1903),
                            Grade = 4,
                            UserId = new Guid("da9b2344-4237-4868-ad78-5e1e35a467fe")
                        },
                        new
                        {
                            Id = new Guid("dde79b77-dd70-4199-b976-26d5d32f7515"),
                            Content = "Читаю каждый день, по 5 часов в день, очень благодарна данному проекта моего знакомого-друга Азиза!",
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1906),
                            Grade = 5,
                            UserId = new Guid("85e3c09a-fa0c-4499-97c8-64644e588023")
                        });
                });

            modelBuilder.Entity("Domain.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 6, 4, 21, 47, 58, 637, DateTimeKind.Utc).AddTicks(9407),
                            Name = "Гость"
                        },
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 6, 4, 21, 47, 58, 637, DateTimeKind.Utc).AddTicks(9413),
                            Name = "Админ"
                        });
                });

            modelBuilder.Entity("Domain.Entities.SessionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b21d68f-38ed-477f-9978-cf82e7aa0cf7"),
                            Created = new DateTime(2024, 6, 4, 21, 47, 58, 638, DateTimeKind.Utc).AddTicks(5398),
                            Email = "aziz_guest@gmail.com",
                            PasswordHash = "$2a$11$vNV5saU9cue78kQwiErK2eV20Py7JkzCoyl98W.lkspc5IxV6Dmpm",
                            PicturePath = "Files//Images//ProfilePictures//7.jpg",
                            RoleId = 2,
                            Username = "aziz_guest"
                        },
                        new
                        {
                            Id = new Guid("62ebe9ad-042f-4488-a22d-142a6d2b2512"),
                            Created = new DateTime(2024, 6, 4, 21, 47, 58, 788, DateTimeKind.Utc).AddTicks(196),
                            Email = "aziz_admin@gmail.com",
                            PasswordHash = "$2a$11$Xvfs1KIZ3/ZL9Hkgivy3b.zOl1hk0KxZlVFpLXdlzKyjshH8biFrq",
                            PicturePath = "Files//Images//ProfilePictures//7.jpg",
                            RoleId = 1,
                            Username = "aziz_admin"
                        },
                        new
                        {
                            Id = new Guid("cdc4a3b4-125f-47f6-8a26-99d057c47d5b"),
                            Created = new DateTime(2024, 6, 4, 21, 47, 58, 939, DateTimeKind.Utc).AddTicks(2384),
                            Email = "amir_guest@gmail.com",
                            PasswordHash = "$2a$11$py/KAjenZzpQLTYIm8E6C..7lq7RheGudfJlfVn6F/rBL0y4z7OlO",
                            PicturePath = "Files//Images//ProfilePictures//1.png",
                            RoleId = 2,
                            Username = "amir_hairulin"
                        },
                        new
                        {
                            Id = new Guid("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5"),
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 88, DateTimeKind.Utc).AddTicks(6452),
                            Email = "adel_guest@gmail.com",
                            PasswordHash = "$2a$11$xq1HBSfoMQjWSJurCxU7NO8Xi.6lmzTbhY02oc44fYM7BK5HVw3AO",
                            PicturePath = "Files//Images//ProfilePictures//2.png",
                            RoleId = 2,
                            Username = "adel_shpahina"
                        },
                        new
                        {
                            Id = new Guid("08278464-1115-440e-b6ab-5f70d77db79d"),
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 238, DateTimeKind.Utc).AddTicks(7039),
                            Email = "bulat_guest@gmail.com",
                            PasswordHash = "$2a$11$17QMNnwiHbQJP0KHvt4vxeVfyqb./wKQKtiKnxOfNgvra5hSkexa2",
                            PicturePath = "Files//Images//ProfilePictures//3.png",
                            RoleId = 2,
                            Username = "bulat_zakirov"
                        },
                        new
                        {
                            Id = new Guid("2f25fde8-c877-407c-adc9-cad036363c53"),
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 393, DateTimeKind.Utc).AddTicks(4553),
                            Email = "ilsia_guest@gmail.com",
                            PasswordHash = "$2a$11$HpQNNyCU3rmKxzOLtAmayOucgsoI5ITlR8Mg31QsWtQG1jU96usEq",
                            PicturePath = "Files//Images//ProfilePictures//4.png",
                            RoleId = 2,
                            Username = "ilsia_iabarova"
                        },
                        new
                        {
                            Id = new Guid("da9b2344-4237-4868-ad78-5e1e35a467fe"),
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 542, DateTimeKind.Utc).AddTicks(7443),
                            Email = "serega_guest@gmail.com",
                            PasswordHash = "$2a$11$TZ0Zu1iYDcjGKhD11RdqTe385n7yl8zNFyxBdJLTyPOIx.GHCiWi2",
                            PicturePath = "Files//Images//ProfilePictures//5.png",
                            RoleId = 2,
                            Username = "serega_michurin"
                        },
                        new
                        {
                            Id = new Guid("85e3c09a-fa0c-4499-97c8-64644e588023"),
                            Created = new DateTime(2024, 6, 4, 21, 47, 59, 692, DateTimeKind.Utc).AddTicks(1805),
                            Email = "maria_guest@gmail.com",
                            PasswordHash = "$2a$11$VjQRg32r7k5UG8Cnd1hHn..GAmtiSRvS4SzJGxQwrD8Ch6R.SkcmC",
                            PicturePath = "Files//Images//ProfilePictures//6.png",
                            RoleId = 2,
                            Username = "maria_utiasova"
                        });
                });

            modelBuilder.Entity("Domain.Entities.BookEntity", b =>
                {
                    b.HasOne("Domain.Entities.AuthorEntity", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.GenreEntity", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Domain.Entities.OrderEntity", b =>
                {
                    b.HasOne("Domain.Entities.BookEntity", "Book")
                        .WithMany("Orders")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.OrderStatusEntity", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ReviewEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.SessionEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("Domain.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.AuthorEntity", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Domain.Entities.BookEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Entities.GenreEntity", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Domain.Entities.OrderStatusEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");

                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}