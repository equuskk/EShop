using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.DataAccess.Migrations
{
    public partial class AddColumnImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "Date",
                                        "Reviews");

            migrationBuilder.DropColumn(
                                        "RegisterDate",
                                        "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                                               "Image",
                                               "Products",
                                               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "Image",
                                        "Products");

            migrationBuilder.AddColumn<DateTime>(
                                                 "Date",
                                                 "Reviews",
                                                 nullable: false,
                                                 defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0,
                                                                            DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                                                 "RegisterDate",
                                                 "AspNetUsers",
                                                 nullable: false,
                                                 defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0,
                                                                            DateTimeKind.Unspecified));
        }
    }
}