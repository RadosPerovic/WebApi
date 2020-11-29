using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTaskManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Members_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeEstimation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tasks_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 11, "Ovo je projekat iz EF Code first", "WebApi" },
                    { 12, "Ovo je projekat iz EF Code first", "InformationSystem" },
                    { 13, "Ovo je projekat iz EF Code first", "ERP" },
                    { 14, "Ovo je projekat iz EF Code first", "CMS" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ID", "Name", "ProjectID", "Surname" },
                values: new object[,]
                {
                    { 21, "Rados", 11, "Perovic" },
                    { 25, "Rados2", 11, "Perovic2" },
                    { 22, "Marko", 12, "Nikolic" },
                    { 26, "Marko2", 12, "Nikolic2" },
                    { 23, "Nikola", 13, "Stefanovic" },
                    { 27, "Nikola2", 13, "Stefanovic2" },
                    { 24, "Milica", 14, "Spasic2" },
                    { 28, "Milica2", 14, "Spasic2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_ProjectID",
                table: "Members",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MemberID",
                table: "Tasks",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectID",
                table: "Tasks",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
