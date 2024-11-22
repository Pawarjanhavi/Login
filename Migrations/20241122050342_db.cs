using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Login.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "EmailId", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John", "Doe", "password123", "johndoe" },
                    { 2, "janedoe@example.com", "Jane", "Doe", "password456", "janedoe" },
                    { 3, "michael.smith@example.com", "Michael", "Smith", "michael123", "michaelsmith" },
                    { 4, "emily.johnson@example.com", "Emily", "Johnson", "emily2024", "emilyj" },
                    { 5, "william.brown@example.com", "William", "Brown", "william@321", "william_b" },
                    { 6, "olivia.taylor@example.com", "Olivia", "Taylor", "olivia@123", "olivia_t" },
                    { 7, "james.martinez@example.com", "James", "Martinez", "james456", "james_m" },
                    { 8, "sophia.davis@example.com", "Sophia", "Davis", "sophia789", "sophia.d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
