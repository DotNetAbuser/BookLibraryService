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
                    Count = table.Column<int>(type: "integer", nullable: false),
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
                    { 1, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2091), "Александр", "Шпак", "", "Files//Images//AuthorPictures//1.jpg", null },
                    { 2, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2106), "Оксана", "Сижулина", "", "Files//Images//AuthorPictures//2.jpg", null },
                    { 3, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2108), "Петр", "Кировский", "", "Files//Images//AuthorPictures//3.jpg", null },
                    { 4, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2110), "Адель", "Каитская", "", "Files//Images//AuthorPictures//4.jpg", null },
                    { 5, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2112), "Михаил", "Кармов", "", "Files//Images//AuthorPictures//5.jpg", null },
                    { 6, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2115), "Виолета", "Сергеева", "", "Files//Images//AuthorPictures//6.jpg", null },
                    { 7, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(2116), "Азиз", "Тураев", "Автор", "Files//Images//AuthorPictures//7.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9514), "Сказки", null },
                    { 2, new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9523), "Детектив", null },
                    { 3, new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9525), "Роман", null },
                    { 4, new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9526), "Комедия", null },
                    { 5, new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(9528), "Драма", null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(9269), "Ожидает получения", null },
                    { 2, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(9279), "Взята в пользование", null },
                    { 3, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(9281), "Ожидает возврата", null },
                    { 4, new DateTime(2024, 6, 4, 21, 47, 59, 843, DateTimeKind.Utc).AddTicks(9282), "Закрыта", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 21, 47, 58, 637, DateTimeKind.Utc).AddTicks(9413), "Админ", null },
                    { 2, new DateTime(2024, 6, 4, 21, 47, 58, 637, DateTimeKind.Utc).AddTicks(9407), "Гость", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "PasswordHash", "PicturePath", "RoleId", "Updated", "Username" },
                values: new object[,]
                {
                    { new Guid("08278464-1115-440e-b6ab-5f70d77db79d"), new DateTime(2024, 6, 4, 21, 47, 59, 238, DateTimeKind.Utc).AddTicks(7039), "bulat_guest@gmail.com", "$2a$11$17QMNnwiHbQJP0KHvt4vxeVfyqb./wKQKtiKnxOfNgvra5hSkexa2", "Files//Images//ProfilePictures//3.png", 2, null, "bulat_zakirov" },
                    { new Guid("2f25fde8-c877-407c-adc9-cad036363c53"), new DateTime(2024, 6, 4, 21, 47, 59, 393, DateTimeKind.Utc).AddTicks(4553), "ilsia_guest@gmail.com", "$2a$11$HpQNNyCU3rmKxzOLtAmayOucgsoI5ITlR8Mg31QsWtQG1jU96usEq", "Files//Images//ProfilePictures//4.png", 2, null, "ilsia_iabarova" },
                    { new Guid("3b21d68f-38ed-477f-9978-cf82e7aa0cf7"), new DateTime(2024, 6, 4, 21, 47, 58, 638, DateTimeKind.Utc).AddTicks(5398), "aziz_guest@gmail.com", "$2a$11$vNV5saU9cue78kQwiErK2eV20Py7JkzCoyl98W.lkspc5IxV6Dmpm", "Files//Images//ProfilePictures//7.jpg", 2, null, "aziz_guest" },
                    { new Guid("62ebe9ad-042f-4488-a22d-142a6d2b2512"), new DateTime(2024, 6, 4, 21, 47, 58, 788, DateTimeKind.Utc).AddTicks(196), "aziz_admin@gmail.com", "$2a$11$Xvfs1KIZ3/ZL9Hkgivy3b.zOl1hk0KxZlVFpLXdlzKyjshH8biFrq", "Files//Images//ProfilePictures//7.jpg", 1, null, "aziz_admin" },
                    { new Guid("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5"), new DateTime(2024, 6, 4, 21, 47, 59, 88, DateTimeKind.Utc).AddTicks(6452), "adel_guest@gmail.com", "$2a$11$xq1HBSfoMQjWSJurCxU7NO8Xi.6lmzTbhY02oc44fYM7BK5HVw3AO", "Files//Images//ProfilePictures//2.png", 2, null, "adel_shpahina" },
                    { new Guid("85e3c09a-fa0c-4499-97c8-64644e588023"), new DateTime(2024, 6, 4, 21, 47, 59, 692, DateTimeKind.Utc).AddTicks(1805), "maria_guest@gmail.com", "$2a$11$VjQRg32r7k5UG8Cnd1hHn..GAmtiSRvS4SzJGxQwrD8Ch6R.SkcmC", "Files//Images//ProfilePictures//6.png", 2, null, "maria_utiasova" },
                    { new Guid("cdc4a3b4-125f-47f6-8a26-99d057c47d5b"), new DateTime(2024, 6, 4, 21, 47, 58, 939, DateTimeKind.Utc).AddTicks(2384), "amir_guest@gmail.com", "$2a$11$py/KAjenZzpQLTYIm8E6C..7lq7RheGudfJlfVn6F/rBL0y4z7OlO", "Files//Images//ProfilePictures//1.png", 2, null, "amir_hairulin" },
                    { new Guid("da9b2344-4237-4868-ad78-5e1e35a467fe"), new DateTime(2024, 6, 4, 21, 47, 59, 542, DateTimeKind.Utc).AddTicks(7443), "serega_guest@gmail.com", "$2a$11$TZ0Zu1iYDcjGKhD11RdqTe385n7yl8zNFyxBdJLTyPOIx.GHCiWi2", "Files//Images//ProfilePictures//5.png", 2, null, "serega_michurin" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "Created", "Grade", "Updated", "UserId" },
                values: new object[,]
                {
                    { new Guid("5f48896f-07d7-49da-98a5-220ec0eb179b"), "Пользуюсь услугами этой организации уже 2 года очень довольна, всегда есть что взять почитать!", new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1899), 5, null, new Guid("2f25fde8-c877-407c-adc9-cad036363c53") },
                    { new Guid("80d88135-2b4d-44b5-8bc8-45e017ddc7d5"), "Брал книгу в аренду на 1 месяц, после чего продлил еще на один, остался очень доволен!", new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1820), 5, null, new Guid("cdc4a3b4-125f-47f6-8a26-99d057c47d5b") },
                    { new Guid("822b6229-551f-4f61-aa4f-46713557a360"), "Брал для учебы учебник по математике 11 класс, смогу подготовиться к ЕГЭ и сдал его на 82 балла, очень благодарен", new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1903), 4, null, new Guid("da9b2344-4237-4868-ad78-5e1e35a467fe") },
                    { new Guid("c98f6c30-4bcf-412b-a0ae-dd63ff9bfbde"), "Брал повесть о похождениях Петра Великого очень понравился рекомендую!", new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1896), 4, null, new Guid("08278464-1115-440e-b6ab-5f70d77db79d") },
                    { new Guid("cd5f9608-2cba-4a48-b93d-d9decb7d0e96"), "Взяла на 2 недели сказку, Репка мне очень понравилась.", new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1891), 5, null, new Guid("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5") },
                    { new Guid("dde79b77-dd70-4199-b976-26d5d32f7515"), "Читаю каждый день, по 5 часов в день, очень благодарна данному проекта моего знакомого-друга Азиза!", new DateTime(2024, 6, 4, 21, 47, 59, 842, DateTimeKind.Utc).AddTicks(1906), 5, null, new Guid("85e3c09a-fa0c-4499-97c8-64644e588023") }
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
