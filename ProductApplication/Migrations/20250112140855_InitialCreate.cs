using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" CREATE SEQUENCE ProductIdSequence  START WITH 100000 INCREMENT BY 1 MINVALUE 100000;");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.Sql(@" CREATE PROCEDURE GetProductId
            AS
            BEGIN
                SET NOCOUNT ON;
                SELECT NEXT VALUE FOR ProductIdSequence AS ProductId;
                SET NOCOUNT OFF;
            END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
            migrationBuilder.Sql("DROP SEQUENCE IF EXISTS ProductIdSequence;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetProductId;");
        }
    }
}
