using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name", "UpdatedById", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2020, 2, 9, 3, 16, 3, 636, DateTimeKind.Unspecified).AddTicks(5422), new TimeSpan(0, 0, 0, 0, 0)), "Living Room", null, null },
                    { 2, 1, new DateTimeOffset(new DateTime(2020, 2, 9, 3, 16, 3, 639, DateTimeKind.Unspecified).AddTicks(4958), new TimeSpan(0, 0, 0, 0, 0)), "BedRoom", null, null },
                    { 3, 1, new DateTimeOffset(new DateTime(2020, 2, 9, 3, 16, 3, 639, DateTimeKind.Unspecified).AddTicks(5025), new TimeSpan(0, 0, 0, 0, 0)), "Kitchen Room", null, null },
                    { 4, 1, new DateTimeOffset(new DateTime(2020, 2, 9, 3, 16, 3, 639, DateTimeKind.Unspecified).AddTicks(5031), new TimeSpan(0, 0, 0, 0, 0)), "Dining Room", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
