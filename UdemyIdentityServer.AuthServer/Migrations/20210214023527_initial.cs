using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyIdentityServer.AuthServer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "customUsers",
                columns: new[] { "Id", "City", "Email", "Password", "UserName" },
                values: new object[] { 1, "Bursa", "emresimsek801@gmail.com", "password", "esimsek" });

            migrationBuilder.InsertData(
                table: "customUsers",
                columns: new[] { "Id", "City", "Email", "Password", "UserName" },
                values: new object[] { 2, "Ankara", "ugur801@gmail.com", "password", "uciftci" });

            migrationBuilder.InsertData(
                table: "customUsers",
                columns: new[] { "Id", "City", "Email", "Password", "UserName" },
                values: new object[] { 3, "İzmir", "mehmet@gmail.com", "password", "mcarp" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customUsers");
        }
    }
}
