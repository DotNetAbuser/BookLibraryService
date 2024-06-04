using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PicturePath = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    PicturePath = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    PicturePath = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    TakenFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TakenTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Created", "FirstName", "LastName", "MiddleName", "PicturePath", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(9849), "Александр", "Шпак", "", "Files//Images//AuthorPictures//1.jpg", null },
                    { 2, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(9860), "Оксана", "Сижулина", "", "Files//Images//AuthorPictures//2.jpg", null },
                    { 3, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(9862), "Петр", "Кировский", "", "Files//Images//AuthorPictures//3.jpg", null },
                    { 4, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(9864), "Адель", "Каитская", "", "Files//Images//AuthorPictures//4.jpg", null },
                    { 5, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(9865), "Михаил", "Кармов", "", "Files//Images//AuthorPictures//5.jpg", null },
                    { 6, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(9868), "Виолета", "Сергеева", "", "Files//Images//AuthorPictures//6.jpg", null },
                    { 7, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(9869), "Азиз", "Тураев", "Автор", "Files//Images//AuthorPictures//7.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7660), "Сказки", null },
                    { 2, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7671), "Детектив", null },
                    { 3, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7672), "Роман", null },
                    { 4, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7674), "Комедия", null },
                    { 5, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7675), "Драма", null },
                    { 6, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7678), "Новелла", null },
                    { 7, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7679), "Бизнес", null },
                    { 8, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7680), "Образование", null },
                    { 9, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7681), "Мистика", null },
                    { 10, new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(7683), "Черный юмор", null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(6665), "Ожидает получения", null },
                    { 2, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(6714), "Взята в пользование", null },
                    { 3, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(6716), "Ожидает возврата", null },
                    { 4, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(6717), "Закрыта", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 23, 8, 57, 742, DateTimeKind.Utc).AddTicks(5957), "Админ", null },
                    { 2, new DateTime(2024, 6, 4, 23, 8, 57, 742, DateTimeKind.Utc).AddTicks(5951), "Гость", null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Created", "Description", "GenreId", "PicturePath", "Quantity", "Title", "Updated", "Year" },
                values: new object[,]
                {
                    { new Guid("02d13e34-d450-4498-b8fe-1a2cb20d103f"), 2, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4189), "Баш и Люси описание", 1, "Files//Images//BookPictures//1.jpg", 3, "Баш и Люси", null, 1990 },
                    { new Guid("083a377b-b4fe-49cb-91fa-e2bec94b9147"), 7, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4259), "Разбитый описание", 2, "Files//Images//BookPictures//14.jpg", 3, "Разбитый", null, 2011 },
                    { new Guid("1bdb5972-46cc-4c27-a5dc-59f0dc5aa0dc"), 6, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4230), "Свободное падение описание", 6, "Files//Images//BookPictures//7.jpg", 6, "Свободное падение", null, 2009 },
                    { new Guid("576c0c85-9650-447f-8027-d484b4384e85"), 6, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4252), "Радикальное садоводство описание", 8, "Files//Images//BookPictures//12.jpg", 1, "Радикальное садоводство", null, 2010 },
                    { new Guid("5c849de3-9761-4073-97ee-61d137b6b7d1"), 4, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4270), "Мир абстрактных цветов!", 8, "Files//Images//BookPictures//17.jpg", 0, "Мир абстрактных цветов", null, 2020 },
                    { new Guid("6167e0ae-4fcd-4f72-81b0-d679e115f310"), 5, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4221), "умные земли описание", 7, "Files//Images//BookPictures//4.jpg", 12, "Умные земли", null, 2005 },
                    { new Guid("657fe962-fedb-4461-83e3-f8c489aff837"), 2, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4262), "", 3, "Files//Images//BookPictures//15.jpg", 8, "Девушки чернил и звёзд", null, 2013 },
                    { new Guid("7ce0c205-63d9-45a2-b00c-8dbeba546359"), 2, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4255), "Красная королева описание", 9, "Files//Images//BookPictures//13.jpg", 10, "Красная королева", null, 2017 },
                    { new Guid("835ba0d7-a821-4f0a-a47a-ddd2f3d97104"), 4, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4218), "Скучные девчонки описание", 6, "Files//Images//BookPictures//3.jpg", 10, "Скучные девчонки", null, 2001 },
                    { new Guid("88d551bd-8ff9-4e5c-88ad-4fa4b6d5a7a7"), 7, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4243), "Святой дух описание", 9, "Files//Images//BookPictures//9.jpg", 0, "Святой дух", null, 2001 },
                    { new Guid("a6e33b25-ac4a-4d68-9ef2-cf168ac1e633"), 2, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4214), "Будь здорова пчелка описание", 1, "Files//Images//BookPictures//2.jpg", 2, "Будь здорова пчелка", null, 1995 },
                    { new Guid("ad97e8ae-ecb4-495b-837a-cbb5cdba4d0d"), 1, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4249), "Ночная тень описание", 6, "Files//Images//BookPictures//11.jpg", 9, "Ночная тень", null, 2010 },
                    { new Guid("c62dae1e-7368-4d78-84ce-95b2723f0884"), 1, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4228), "Экономика агропромышленности описание", 8, "Files//Images//BookPictures//6.jpg", 1, "Экономика агропромышленности", null, 2000 },
                    { new Guid("d5d3037c-73f5-4981-be13-15763b6a1ef5"), 7, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4267), "Счастливый лимон описание", 1, "Files//Images//BookPictures//16.jpg", 12, "Счастливый лимон", null, 2000 },
                    { new Guid("f2d4027c-9e6e-4755-ab0f-5154d1d36b41"), 2, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4247), "Апокалипсис Ллойда описание", 10, "Files//Images//BookPictures//10.jpg", 1, "Апокалипсис Ллойда", null, 2019 },
                    { new Guid("f5b4baae-92e5-4a64-bc5d-162f087023eb"), 1, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4240), "Современная архитектура зданий описание", 8, "Files//Images//BookPictures//8.jpg", 4, "Современная архитектура зданий", null, 2018 },
                    { new Guid("fc527fe1-7228-455e-bef5-73091c5940bb"), 6, new DateTime(2024, 6, 4, 23, 8, 58, 955, DateTimeKind.Utc).AddTicks(4224), "Темная сторона интернета описание", 8, "Files//Images//BookPictures//5.jpg", 10, "Темная сторона интернета", null, 2012 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "PasswordHash", "PicturePath", "RoleId", "Updated", "Username" },
                values: new object[,]
                {
                    { new Guid("08278464-1115-440e-b6ab-5f70d77db79d"), new DateTime(2024, 6, 4, 23, 8, 58, 346, DateTimeKind.Utc).AddTicks(1768), "bulat_guest@gmail.com", "$2a$11$/atflsAIHYtzj.Slm.ZOh.0I0CPWUqmlsVSLP2hm8AddPi5Yd51tK", "Files//Images//ProfilePictures//3.png", 2, null, "bulat_zakirov" },
                    { new Guid("142821dd-b1f5-4e19-8ab3-c89428c1b143"), new DateTime(2024, 6, 4, 23, 8, 57, 892, DateTimeKind.Utc).AddTicks(9463), "aziz_admin@gmail.com", "$2a$11$qqqkhujKl3Z81qeWcS256.Ted7u.cj/H2BStMG/UOixdgSjZdVwbO", "Files//Images//ProfilePictures//7.jpg", 1, null, "aziz_admin" },
                    { new Guid("2f25fde8-c877-407c-adc9-cad036363c53"), new DateTime(2024, 6, 4, 23, 8, 58, 501, DateTimeKind.Utc).AddTicks(3272), "ilsia_guest@gmail.com", "$2a$11$pK2.5g68QezDI6jY0df61uvDLEEJ7y17GpNMb7kbi4SIcC0HNxrFy", "Files//Images//ProfilePictures//4.png", 2, null, "ilsia_iabarova" },
                    { new Guid("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5"), new DateTime(2024, 6, 4, 23, 8, 58, 194, DateTimeKind.Utc).AddTicks(1658), "adel_guest@gmail.com", "$2a$11$V18lehEFFzynRqTtftLMZe20CO/jzWzBMsBYKwUC/0qo.NdDSDsOK", "Files//Images//ProfilePictures//2.png", 2, null, "adel_shpahina" },
                    { new Guid("85e3c09a-fa0c-4499-97c8-64644e588023"), new DateTime(2024, 6, 4, 23, 8, 58, 803, DateTimeKind.Utc).AddTicks(7147), "maria_guest@gmail.com", "$2a$11$qL8duVsEHM6Q9KGgNlnb6e/vIaZv6WZYIiZlok/D6.3chWVrHy9OG", "Files//Images//ProfilePictures//6.png", 2, null, "maria_utiasova" },
                    { new Guid("c10ccde9-33f3-4ecb-9070-1f7c1d3b3f7e"), new DateTime(2024, 6, 4, 23, 8, 57, 743, DateTimeKind.Utc).AddTicks(2266), "aziz_guest@gmail.com", "$2a$11$TWJJo6wjRtEueFY7gAiQQeQhgNaOijIpB1zX0wrks/37zxmM9Kgl2", "Files//Images//ProfilePictures//7.jpg", 2, null, "aziz_guest" },
                    { new Guid("cdc4a3b4-125f-47f6-8a26-99d057c47d5b"), new DateTime(2024, 6, 4, 23, 8, 58, 44, DateTimeKind.Utc).AddTicks(6290), "amir_guest@gmail.com", "$2a$11$F9VvALoH64YZbmb6B0Ddxed//TS6lxjUgNopFhRVOEOjU/kEIGuhi", "Files//Images//ProfilePictures//1.png", 2, null, "amir_hairulin" },
                    { new Guid("da9b2344-4237-4868-ad78-5e1e35a467fe"), new DateTime(2024, 6, 4, 23, 8, 58, 654, DateTimeKind.Utc).AddTicks(4734), "serega_guest@gmail.com", "$2a$11$tNvaYGZIWrKfv3bHb1ERke7pxus3/O2IMCo8hd6TIxKn9nL/cKDs6", "Files//Images//ProfilePictures//5.png", 2, null, "serega_michurin" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "Created", "Grade", "Updated", "UserId" },
                values: new object[,]
                {
                    { new Guid("15271d4f-e666-4b9f-a64f-77ac12590a99"), "Брал книгу в аренду на 1 месяц, после чего продлил еще на один, остался очень доволен!", new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(157), 5, null, new Guid("cdc4a3b4-125f-47f6-8a26-99d057c47d5b") },
                    { new Guid("4a2ddcf2-41a4-4629-90c5-56c56d7b4453"), "Пользуюсь услугами этой организации уже 2 года очень довольна, всегда есть что взять почитать!", new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(329), 5, null, new Guid("2f25fde8-c877-407c-adc9-cad036363c53") },
                    { new Guid("672a081a-9a61-483d-aaa8-22df02796e6f"), "Взяла на 2 недели сказку, Репка мне очень понравилась.", new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(231), 5, null, new Guid("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5") },
                    { new Guid("cc830007-b62f-4804-ad28-825edea71bb2"), "Читаю каждый день, по 5 часов в день, очень благодарна данному проекта моего знакомого-друга Азиза!", new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(356), 5, null, new Guid("85e3c09a-fa0c-4499-97c8-64644e588023") },
                    { new Guid("d21ad6fc-cbb8-4be1-bbf7-01638551906d"), "Брал для учебы учебник по математике 11 класс, смогу подготовиться к ЕГЭ и сдал его на 82 балла, очень благодарен", new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(334), 4, null, new Guid("da9b2344-4237-4868-ad78-5e1e35a467fe") },
                    { new Guid("f7248545-7ee2-4a5c-b06a-83bee9dd4efc"), "Брал повесть о похождениях Петра Великого очень понравился рекомендую!", new DateTime(2024, 6, 4, 23, 8, 58, 954, DateTimeKind.Utc).AddTicks(236), 4, null, new Guid("08278464-1115-440e-b6ab-5f70d77db79d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuses_Name",
                table: "OrderStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
