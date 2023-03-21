using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IssuesSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devolopers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devolopers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devolopers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevoloperTicket",
                columns: table => new
                {
                    devolopersId = table.Column<int>(type: "int", nullable: false),
                    ticketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevoloperTicket", x => new { x.devolopersId, x.ticketsId });
                    table.ForeignKey(
                        name: "FK_DevoloperTicket_Devolopers_devolopersId",
                        column: x => x.devolopersId,
                        principalTable: "Devolopers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DevoloperTicket_Tickets_ticketsId",
                        column: x => x.ticketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Automotive & Baby" },
                    { 2, "Beauty & Health" },
                    { 3, "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Devolopers",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Diabetes" },
                    { 2, 2, "Hypertension" },
                    { 3, 2, "Asthma" },
                    { 4, 1, "Depression" },
                    { 5, 1, "Arthritis" },
                    { 6, 3, "Allergy" },
                    { 7, 3, "Flu" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DepartmentId", "Description", "Severity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Rerum totam est quo possimus sunt sunt ad.", 0, "id" },
                    { 2, 3, "Id cumque explicabo beatae.", 1, "dicta" },
                    { 3, 2, "Consectetur beatae dolorem voluptates occaecati.", 0, "eius" },
                    { 4, 1, "Nulla est doloribus ut non aspernatur vero dolores.", 2, "assumenda" },
                    { 5, 2, "Et praesentium est ipsum eligendi rerum itaque voluptate quia.", 1, "ex" },
                    { 6, 3, "Optio non debitis ut molestiae dolorem ad.", 2, "velit" },
                    { 20, 2, "Harum hic impedit dolore voluptate placeat.", 1, "in" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devolopers_DepartmentId",
                table: "Devolopers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DevoloperTicket_ticketsId",
                table: "DevoloperTicket",
                column: "ticketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartmentId",
                table: "Tickets",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevoloperTicket");

            migrationBuilder.DropTable(
                name: "Devolopers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
