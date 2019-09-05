using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.DataAccess.Migrations
{
    public partial class AddSetterInDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                                                 "Date",
                                                 "Reviews",
                                                 nullable: false,
                                                 defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0,
                                                                            DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "Date",
                                        "Reviews");
        }
    }
}