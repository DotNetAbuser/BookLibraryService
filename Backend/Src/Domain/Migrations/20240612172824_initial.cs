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
                    { 1, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(4780), "Александр", "Шпак", "", "Files//Images//AuthorPictures//1.jpg", null },
                    { 2, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(4789), "Оксана", "Сижулина", "", "Files//Images//AuthorPictures//2.jpg", null },
                    { 3, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(4791), "Петр", "Кировский", "", "Files//Images//AuthorPictures//3.jpg", null },
                    { 4, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(4793), "Адель", "Каитская", "", "Files//Images//AuthorPictures//4.jpg", null },
                    { 5, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(4795), "Михаил", "Кармов", "", "Files//Images//AuthorPictures//5.jpg", null },
                    { 6, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(4797), "Виолета", "Сергеева", "", "Files//Images//AuthorPictures//6.jpg", null },
                    { 7, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(4799), "Азиз", "Тураев", "Автор", "Files//Images//AuthorPictures//7.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2589), "Сказки", null },
                    { 2, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2647), "Детектив", null },
                    { 3, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2649), "Роман", null },
                    { 4, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2650), "Комедия", null },
                    { 5, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2651), "Драма", null },
                    { 6, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2654), "Новелла", null },
                    { 7, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2655), "Бизнес", null },
                    { 8, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2656), "Образование", null },
                    { 9, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2657), "Мистика", null },
                    { 10, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(2659), "Черный юмор", null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 12, 17, 28, 24, 111, DateTimeKind.Utc).AddTicks(1802), "Ожидает получения", null },
                    { 2, new DateTime(2024, 6, 12, 17, 28, 24, 111, DateTimeKind.Utc).AddTicks(1811), "Взята в пользование", null },
                    { 3, new DateTime(2024, 6, 12, 17, 28, 24, 111, DateTimeKind.Utc).AddTicks(1813), "Ожидается подтверждения продления", null },
                    { 4, new DateTime(2024, 6, 12, 17, 28, 24, 111, DateTimeKind.Utc).AddTicks(1814), "Ожидает возврата", null },
                    { 5, new DateTime(2024, 6, 12, 17, 28, 24, 111, DateTimeKind.Utc).AddTicks(1815), "Закрыта", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 12, 17, 28, 22, 903, DateTimeKind.Utc).AddTicks(5289), "Библиотекарь", null },
                    { 2, new DateTime(2024, 6, 12, 17, 28, 22, 903, DateTimeKind.Utc).AddTicks(5284), "Гость", null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Created", "Description", "GenreId", "PicturePath", "Quantity", "Title", "Updated", "Year" },
                values: new object[,]
                {
                    { new Guid("11b4a44c-ad4d-43ef-839d-01d4e13417e3"), 5, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9242), "умные земли описание", 7, "Files//Images//BookPictures//4.jpg", 12, "Умные земли", null, 2005 },
                    { new Guid("1d84ae73-0b64-4854-b463-a75d9b86bb6c"), 2, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9235), "Будь здорова пчелка описание", 1, "Files//Images//BookPictures//2.jpg", 2, "Будь здорова пчелка", null, 1995 },
                    { new Guid("2327a73b-09f3-431f-bb65-3788c41fe147"), 1, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9268), "Ночная тень описание", 6, "Files//Images//BookPictures//11.jpg", 9, "Ночная тень", null, 2010 },
                    { new Guid("2838be61-ff5c-4321-97b4-304535e3e867"), 4, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9327), "Мир абстрактных цветов!", 8, "Files//Images//BookPictures//17.jpg", 0, "Мир абстрактных цветов", null, 2020 },
                    { new Guid("38672bb4-adb1-4481-a962-e8209a426da7"), 2, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9209), "Баш и Люси описание", 1, "Files//Images//BookPictures//1.jpg", 3, "Баш и Люси", null, 1990 },
                    { new Guid("52f83ea8-0e9e-4f94-b747-780d92794f2a"), 6, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9271), "Радикальное садоводство описание", 8, "Files//Images//BookPictures//12.jpg", 1, "Радикальное садоводство", null, 2010 },
                    { new Guid("53346b3f-1c7b-4a3a-a404-119ec7c25f5b"), 4, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9239), "Скучные девчонки описание", 6, "Files//Images//BookPictures//3.jpg", 10, "Скучные девчонки", null, 2001 },
                    { new Guid("7136ba70-11b4-4451-8eee-1ed86787f78c"), 1, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9248), "Экономика агропромышленности описание", 8, "Files//Images//BookPictures//6.jpg", 1, "Экономика агропромышленности", null, 2000 },
                    { new Guid("7938c6cb-0f9b-47b9-a40a-95d45e916fdb"), 7, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9321), "Счастливый лимон описание", 1, "Files//Images//BookPictures//16.jpg", 12, "Счастливый лимон", null, 2000 },
                    { new Guid("7c6fa4fb-1772-4257-9aa7-6092dbbb3982"), 7, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9316), "Разбитый описание", 2, "Files//Images//BookPictures//14.jpg", 3, "Разбитый", null, 2011 },
                    { new Guid("7d48e1b8-de63-49c8-8362-1cad86600207"), 2, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9265), "Апокалипсис Ллойда описание", 10, "Files//Images//BookPictures//10.jpg", 1, "Апокалипсис Ллойда", null, 2019 },
                    { new Guid("9243a8d3-43f6-4032-94ea-558636d85674"), 6, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9250), "Свободное падение описание", 6, "Files//Images//BookPictures//7.jpg", 6, "Свободное падение", null, 2009 },
                    { new Guid("9d3e2086-76ed-4794-bd92-9c834ef582f3"), 2, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9273), "Красная королева описание", 9, "Files//Images//BookPictures//13.jpg", 10, "Красная королева", null, 2017 },
                    { new Guid("ae10a5a4-555b-45b3-a44e-6455dba458dd"), 6, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9244), "Темная сторона интернета описание", 8, "Files//Images//BookPictures//5.jpg", 10, "Темная сторона интернета", null, 2012 },
                    { new Guid("b7ae481a-c9eb-4978-9a54-a8bd39bf7a01"), 7, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9262), "Святой дух описание", 9, "Files//Images//BookPictures//9.jpg", 0, "Святой дух", null, 2001 },
                    { new Guid("da3ba47e-d6ae-4228-bc1e-5d4c33227806"), 1, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9253), "Современная архитектура зданий описание", 8, "Files//Images//BookPictures//8.jpg", 4, "Современная архитектура зданий", null, 2018 },
                    { new Guid("e6ab377b-fb64-4335-95d5-295ffe3647ee"), 2, new DateTime(2024, 6, 12, 17, 28, 24, 110, DateTimeKind.Utc).AddTicks(9319), "", 3, "Files//Images//BookPictures//15.jpg", 8, "Девушки чернил и звёзд", null, 2013 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "PasswordHash", "PicturePath", "RoleId", "Updated", "Username" },
                values: new object[,]
                {
                    { new Guid("08278464-1115-440e-b6ab-5f70d77db79d"), new DateTime(2024, 6, 12, 17, 28, 23, 510, DateTimeKind.Utc).AddTicks(6206), "bulat_guest@gmail.com", "$2a$11$IzVK9IMcq60p2qa9aEEWDuKxREQHY63T40hG8Mby46uXKdb71paPG", "Files//Images//ProfilePictures//3.png", 2, null, "bulat_zakirov" },
                    { new Guid("1da5fcbf-5d3b-4caa-ae9a-3669c2a9ab28"), new DateTime(2024, 6, 12, 17, 28, 23, 53, DateTimeKind.Utc).AddTicks(4499), "aziz_librarian@gmail.com", "$2a$11$4GUuWIe7NA8vvd3nbjkTaeKVGfQtyq1liDjJftAsbxkf3.jToVrQK", "Files//Images//ProfilePictures//7.jpg", 1, null, "aziz_librarian" },
                    { new Guid("2f25fde8-c877-407c-adc9-cad036363c53"), new DateTime(2024, 6, 12, 17, 28, 23, 660, DateTimeKind.Utc).AddTicks(737), "ilsia_guest@gmail.com", "$2a$11$1vcoveHfu1GJgxrN8Rw8Lu7LBN/rPtbRzmsVHi66mRWWZXP0WNley", "Files//Images//ProfilePictures//4.png", 2, null, "ilsia_iabarova" },
                    { new Guid("6e18278e-e363-4e85-8ac7-74915712b816"), new DateTime(2024, 6, 12, 17, 28, 22, 904, DateTimeKind.Utc).AddTicks(1778), "aziz_guest@gmail.com", "$2a$11$DaIMIM6H81Uqrbox5.zYoOM4W28KPPphGhQkOJ28XAxYleVcryLqa", "Files//Images//ProfilePictures//7.jpg", 2, null, "aziz_guest" },
                    { new Guid("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5"), new DateTime(2024, 6, 12, 17, 28, 23, 357, DateTimeKind.Utc).AddTicks(1284), "adel_guest@gmail.com", "$2a$11$yPTPYMjs8bakpGPVXqnvZeP.8H2cpcB4..mOhEg.HspIRfLB/sK5m", "Files//Images//ProfilePictures//2.png", 2, null, "adel_shpahina" },
                    { new Guid("85e3c09a-fa0c-4499-97c8-64644e588023"), new DateTime(2024, 6, 12, 17, 28, 23, 959, DateTimeKind.Utc).AddTicks(4251), "maria_guest@gmail.com", "$2a$11$Nu83V6EQoiUtGcpv155XqOCkOrqenYMcYBoCfvsmAI68TTzMt.NA.", "Files//Images//ProfilePictures//6.png", 2, null, "maria_utiasova" },
                    { new Guid("cdc4a3b4-125f-47f6-8a26-99d057c47d5b"), new DateTime(2024, 6, 12, 17, 28, 23, 207, DateTimeKind.Utc).AddTicks(2138), "amir_guest@gmail.com", "$2a$11$fnHFZv9fHtPd8BB00xp34.cDopJhuusnZocKqS3HixH/yAToJTZiC", "Files//Images//ProfilePictures//1.png", 2, null, "amir_hairulin" },
                    { new Guid("da9b2344-4237-4868-ad78-5e1e35a467fe"), new DateTime(2024, 6, 12, 17, 28, 23, 809, DateTimeKind.Utc).AddTicks(5964), "serega_guest@gmail.com", "$2a$11$IAP7UNYI8jr5QicPuDPdCOWvepbLp5XbBJwUpKoPVuzhbT2WolpDO", "Files//Images//ProfilePictures//5.png", 2, null, "serega_michurin" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "Created", "Grade", "Updated", "UserId" },
                values: new object[,]
                {
                    { new Guid("00cc963c-f0a0-4d67-be95-706eb0230ab1"), "Взяла на 2 недели сказку, Репка мне очень понравилась.", new DateTime(2024, 6, 12, 17, 28, 24, 109, DateTimeKind.Utc).AddTicks(5229), 5, null, new Guid("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5") },
                    { new Guid("0ec37910-7e96-443e-8dc1-f2db08e18974"), "Брал повесть о похождениях Петра Великого очень понравился рекомендую!", new DateTime(2024, 6, 12, 17, 28, 24, 109, DateTimeKind.Utc).AddTicks(5234), 4, null, new Guid("08278464-1115-440e-b6ab-5f70d77db79d") },
                    { new Guid("2b986e1c-1430-4050-8ed7-838291dc4117"), "Пользуюсь услугами этой организации уже 2 года очень довольна, всегда есть что взять почитать!", new DateTime(2024, 6, 12, 17, 28, 24, 109, DateTimeKind.Utc).AddTicks(5257), 5, null, new Guid("2f25fde8-c877-407c-adc9-cad036363c53") },
                    { new Guid("48ac3109-f971-4aca-ac47-3ee4699ae989"), "Брал книгу в аренду на 1 месяц, после чего продлил еще на один, остался очень доволен!", new DateTime(2024, 6, 12, 17, 28, 24, 109, DateTimeKind.Utc).AddTicks(5156), 5, null, new Guid("cdc4a3b4-125f-47f6-8a26-99d057c47d5b") },
                    { new Guid("746edb72-1eb7-450a-9e60-6ceb2d2f7247"), "Брал для учебы учебник по математике 11 класс, смогу подготовиться к ЕГЭ и сдал его на 82 балла, очень благодарен", new DateTime(2024, 6, 12, 17, 28, 24, 109, DateTimeKind.Utc).AddTicks(5259), 4, null, new Guid("da9b2344-4237-4868-ad78-5e1e35a467fe") },
                    { new Guid("96dfd1c6-2689-477a-8519-db9427a8f6a3"), "Читаю каждый день, по 5 часов в день, очень благодарна данному проекта моего знакомого-друга Азиза!", new DateTime(2024, 6, 12, 17, 28, 24, 109, DateTimeKind.Utc).AddTicks(5263), 5, null, new Guid("85e3c09a-fa0c-4499-97c8-64644e588023") }
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
