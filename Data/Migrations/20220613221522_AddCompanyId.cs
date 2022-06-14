using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddCompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Toys");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Toys",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Toys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Company 1" },
                    { 2, "Company 2" },
                    { 3, "Company 3" },
                    { 4, "Company 4" },
                    { 5, "Company 5" }
                });

            migrationBuilder.InsertData(
                table: "Toys",
                columns: new[] { "Id", "AgeRestriction", "CompanyId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 10, 1, "Description toy 1", "Toy 1", 10m },
                    { 2, 10, 2, "Description toy 2", "Toy 2", 20m },
                    { 3, 10, 3, "Description toy 3", "Toy 3", 30m },
                    { 4, 10, 4, "Description toy 4", "Toy 4", 40m },
                    { 5, 10, 5, "Description toy 5", "Toy 5", 50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toys_CompanyId",
                table: "Toys",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Companies_CompanyId",
                table: "Toys",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Companies_CompanyId",
                table: "Toys");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Toys_CompanyId",
                table: "Toys");

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Toys");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Toys",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Toys",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
