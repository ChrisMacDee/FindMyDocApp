using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyDoc.Data.Migrations
{
    public partial class addedrelateddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("e8442dce-e31e-4dd8-a85c-db5f5bb1ba23"));

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "DateCreated", "Deleted", "FullName", "LastUpdated", "PlaceId" },
                values: new object[] { new Guid("33b61872-8744-427f-8eed-967878a97b98"), "123 Fake Street", new DateTime(2021, 4, 22, 14, 0, 46, 258, DateTimeKind.Local).AddTicks(6239), false, "Dr Who", new DateTime(2021, 4, 22, 14, 0, 46, 262, DateTimeKind.Local).AddTicks(1655), "12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33b61872-8744-427f-8eed-967878a97b98"));

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "DateCreated", "Deleted", "FullName", "LastUpdated", "PlaceId" },
                values: new object[] { new Guid("e8442dce-e31e-4dd8-a85c-db5f5bb1ba23"), "123 Fake Street", new DateTime(2021, 4, 22, 13, 56, 11, 419, DateTimeKind.Local).AddTicks(5961), false, "Dr Who", new DateTime(2021, 4, 22, 13, 56, 11, 423, DateTimeKind.Local).AddTicks(2185), "12345" });
        }
    }
}
