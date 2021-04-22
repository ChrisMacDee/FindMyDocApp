using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyDoc.Data.Migrations
{
    public partial class addedseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "DateCreated", "Deleted", "FullName", "LastUpdated", "PlaceId" },
                values: new object[] { new Guid("e8442dce-e31e-4dd8-a85c-db5f5bb1ba23"), "123 Fake Street", new DateTime(2021, 4, 22, 13, 56, 11, 419, DateTimeKind.Local).AddTicks(5961), false, "Dr Who", new DateTime(2021, 4, 22, 13, 56, 11, 423, DateTimeKind.Local).AddTicks(2185), "12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("e8442dce-e31e-4dd8-a85c-db5f5bb1ba23"));
        }
    }
}
