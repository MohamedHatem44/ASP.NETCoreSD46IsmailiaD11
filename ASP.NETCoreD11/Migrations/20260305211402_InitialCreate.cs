using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.NETCoreD11.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, 26, "Ahmed", 1234m },
                    { 2, 36, "Mohamed", 2234m },
                    { 3, 46, "Sara", 4234m },
                    { 4, 25, "Omar", 5234m },
                    { 5, 23, "Ali", 6234m },
                    { 6, 36, "Mai", 7234m },
                    { 7, 49, "Ramy", 8234m },
                    { 8, 18, "Hamada", 9234m },
                    { 9, 26, "Hatem", 10234m },
                    { 10, 25, "Osama", 17234m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
