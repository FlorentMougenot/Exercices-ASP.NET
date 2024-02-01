using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciceOrnithorynque.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlatypusOriginal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    CanSwim = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatypusOriginal", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatypusOriginal");
        }
    }
}
