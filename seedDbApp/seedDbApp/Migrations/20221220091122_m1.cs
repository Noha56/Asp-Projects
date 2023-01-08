using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace seedDbApp.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table => new
                {
                    MobileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "varchar(20)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile", x => x.MobileId);
                });

            migrationBuilder.InsertData(
                table: "Mobile",
                columns: new[] { "MobileId", "Model", "Price" },
                values: new object[,]
                {
                    { 1, "Iphone1", 800m },
                    { 2, "Iphone2", 700m },
                    { 3, "Iphone3", 650m },
                    { 4, "Iphone4", 750m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mobile");
        }
    }
}
