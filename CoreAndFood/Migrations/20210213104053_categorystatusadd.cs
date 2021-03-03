using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAndFood.Migrations
{
    public partial class categorystatusadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CatgoryName",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CatgoryName",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
