using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitializeUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "Password" },
                values: new object[] { new Guid("23c1d128-4187-4485-9011-bdb7ac2ba029"), null, "jorgegrajales090@gmail.com", "Jorge Grajales", "123456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("23c1d128-4187-4485-9011-bdb7ac2ba029"));
        }
    }
}
