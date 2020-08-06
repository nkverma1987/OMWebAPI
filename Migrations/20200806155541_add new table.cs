using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Migrations
{
    public partial class addnewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductClassification",
                table: "Orders",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "OrderLink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductClassification = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLink", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLink");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Orders",
                newName: "ProductClassification");

            migrationBuilder.AddColumn<int>(
                name: "AccountNumber",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
