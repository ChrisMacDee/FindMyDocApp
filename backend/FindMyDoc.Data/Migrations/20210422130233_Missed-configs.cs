using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyDoc.Data.Migrations
{
    public partial class Missedconfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookingApplicants",
                columns: new[] { "Id", "DateCreated", "Deleted", "Email", "EmailLastSent", "FullName", "LastUpdated", "NHSNumber" },
                values: new object[] { new Guid("33b61872-8744-427f-8eed-967878a97b99"), new DateTime(2021, 4, 22, 14, 2, 32, 889, DateTimeKind.Local).AddTicks(870), false, "fakeemail@test.com", new DateTime(2021, 4, 22, 14, 2, 32, 889, DateTimeKind.Local).AddTicks(2576), "Joe Bloggs", new DateTime(2021, 4, 22, 14, 2, 32, 889, DateTimeKind.Local).AddTicks(1461), "1234" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33b61872-8744-427f-8eed-967878a97b98"),
                columns: new[] { "DateCreated", "LastUpdated" },
                values: new object[] { new DateTime(2021, 4, 22, 14, 2, 32, 883, DateTimeKind.Local).AddTicks(1806), new DateTime(2021, 4, 22, 14, 2, 32, 886, DateTimeKind.Local).AddTicks(8240) });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ApplicantId", "BookingDateAndTime", "DateCreated", "Deleted", "DoctorId", "LastUpdated" },
                values: new object[] { new Guid("279d8e19-48b6-44c6-9117-f2619041ce73"), new Guid("33b61872-8744-427f-8eed-967878a97b99"), new DateTime(2021, 4, 22, 14, 2, 32, 890, DateTimeKind.Local).AddTicks(80), new DateTime(2021, 4, 22, 14, 2, 32, 889, DateTimeKind.Local).AddTicks(8890), false, new Guid("33b61872-8744-427f-8eed-967878a97b98"), new DateTime(2021, 4, 22, 14, 2, 32, 889, DateTimeKind.Local).AddTicks(9469) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("279d8e19-48b6-44c6-9117-f2619041ce73"));

            migrationBuilder.DeleteData(
                table: "BookingApplicants",
                keyColumn: "Id",
                keyValue: new Guid("33b61872-8744-427f-8eed-967878a97b99"));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33b61872-8744-427f-8eed-967878a97b98"),
                columns: new[] { "DateCreated", "LastUpdated" },
                values: new object[] { new DateTime(2021, 4, 22, 14, 0, 46, 258, DateTimeKind.Local).AddTicks(6239), new DateTime(2021, 4, 22, 14, 0, 46, 262, DateTimeKind.Local).AddTicks(1655) });
        }
    }
}
