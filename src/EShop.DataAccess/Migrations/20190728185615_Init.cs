using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                                         "AspNetRoles",
                                         table => new
                                         {
                                             Id = table.Column<string>(),
                                             Name = table.Column<string>(maxLength: 256, nullable: true),
                                             NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                                             ConcurrencyStamp = table.Column<string>(nullable: true)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "AspNetUsers",
                                         table => new
                                         {
                                             Id = table.Column<string>(),
                                             UserName = table.Column<string>(maxLength: 256, nullable: true),
                                             NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                                             Email = table.Column<string>(maxLength: 256, nullable: true),
                                             NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                                             EmailConfirmed = table.Column<bool>(),
                                             PasswordHash = table.Column<string>(nullable: true),
                                             SecurityStamp = table.Column<string>(nullable: true),
                                             ConcurrencyStamp = table.Column<string>(nullable: true),
                                             PhoneNumber = table.Column<string>(nullable: true),
                                             PhoneNumberConfirmed = table.Column<bool>(),
                                             TwoFactorEnabled = table.Column<bool>(),
                                             LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                                             LockoutEnabled = table.Column<bool>(),
                                             AccessFailedCount = table.Column<int>(),
                                             FirstName = table.Column<string>(nullable: true),
                                             LastName = table.Column<string>(nullable: true),
                                             Address = table.Column<string>(nullable: true),
                                             RegisterDate = table.Column<DateTime>()
                                         },
                                         constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Categories",
                                         table => new
                                         {
                                             Id = table.Column<int>()
                                                       .Annotation("SqlServer:ValueGenerationStrategy",
                                                                   SqlServerValueGenerationStrategy.IdentityColumn),
                                             Name = table.Column<string>(nullable: true)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_Categories", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Orders",
                                         table => new
                                         {
                                             Id = table.Column<int>()
                                                       .Annotation("SqlServer:ValueGenerationStrategy",
                                                                   SqlServerValueGenerationStrategy.IdentityColumn),
                                             Cost = table.Column<double>()
                                         },
                                         constraints: table => { table.PrimaryKey("PK_Orders", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Vendors",
                                         table => new
                                         {
                                             Id = table.Column<int>()
                                                       .Annotation("SqlServer:ValueGenerationStrategy",
                                                                   SqlServerValueGenerationStrategy.IdentityColumn),
                                             Name = table.Column<string>(nullable: true),
                                             Description = table.Column<string>(nullable: true)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_Vendors", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "AspNetRoleClaims",
                                         table => new
                                         {
                                             Id = table.Column<int>()
                                                       .Annotation("SqlServer:ValueGenerationStrategy",
                                                                   SqlServerValueGenerationStrategy.IdentityColumn),
                                             RoleId = table.Column<string>(),
                                             ClaimType = table.Column<string>(nullable: true),
                                             ClaimValue = table.Column<string>(nullable: true)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                                                              x => x.RoleId,
                                                              "AspNetRoles",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "AspNetUserClaims",
                                         table => new
                                         {
                                             Id = table.Column<int>()
                                                       .Annotation("SqlServer:ValueGenerationStrategy",
                                                                   SqlServerValueGenerationStrategy.IdentityColumn),
                                             UserId = table.Column<string>(),
                                             ClaimType = table.Column<string>(nullable: true),
                                             ClaimValue = table.Column<string>(nullable: true)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_AspNetUserClaims_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "AspNetUserLogins",
                                         table => new
                                         {
                                             LoginProvider = table.Column<string>(),
                                             ProviderKey = table.Column<string>(),
                                             ProviderDisplayName = table.Column<string>(nullable: true),
                                             UserId = table.Column<string>()
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetUserLogins",
                                                              x => new { x.LoginProvider, x.ProviderKey });
                                             table.ForeignKey(
                                                              "FK_AspNetUserLogins_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "AspNetUserRoles",
                                         table => new
                                         {
                                             UserId = table.Column<string>(),
                                             RoleId = table.Column<string>()
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                                             table.ForeignKey(
                                                              "FK_AspNetUserRoles_AspNetRoles_RoleId",
                                                              x => x.RoleId,
                                                              "AspNetRoles",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_AspNetUserRoles_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "AspNetUserTokens",
                                         table => new
                                         {
                                             UserId = table.Column<string>(),
                                             LoginProvider = table.Column<string>(),
                                             Name = table.Column<string>(),
                                             Value = table.Column<string>(nullable: true)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetUserTokens",
                                                              x => new { x.UserId, x.LoginProvider, x.Name });
                                             table.ForeignKey(
                                                              "FK_AspNetUserTokens_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "Products",
                                         table => new
                                         {
                                             Id = table.Column<int>()
                                                       .Annotation("SqlServer:ValueGenerationStrategy",
                                                                   SqlServerValueGenerationStrategy.IdentityColumn),
                                             Name = table.Column<string>(nullable: true),
                                             Description = table.Column<string>(nullable: true),
                                             Price = table.Column<double>(),
                                             VendorId = table.Column<int>(),
                                             CategoryId = table.Column<int>()
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Products", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_Products_Categories_CategoryId",
                                                              x => x.CategoryId,
                                                              "Categories",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_Products_Vendors_VendorId",
                                                              x => x.VendorId,
                                                              "Vendors",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "ProductsInCarts",
                                         table => new
                                         {
                                             Id = table.Column<int>()
                                                       .Annotation("SqlServer:ValueGenerationStrategy",
                                                                   SqlServerValueGenerationStrategy.IdentityColumn),
                                             UserId = table.Column<string>(nullable: true),
                                             ProductId = table.Column<int>(),
                                             OrderId = table.Column<int>(nullable: true),
                                             Quantity = table.Column<int>()
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_ProductsInCarts", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_ProductsInCarts_Orders_OrderId",
                                                              x => x.OrderId,
                                                              "Orders",
                                                              "Id",
                                                              onDelete: ReferentialAction.Restrict);
                                             table.ForeignKey(
                                                              "FK_ProductsInCarts_Products_ProductId",
                                                              x => x.ProductId,
                                                              "Products",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_ProductsInCarts_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Restrict);
                                         });

            migrationBuilder.CreateTable(
                                         "Reviews",
                                         table => new
                                         {
                                             Id = table.Column<int>()
                                                       .Annotation("SqlServer:ValueGenerationStrategy",
                                                                   SqlServerValueGenerationStrategy.IdentityColumn),
                                             UserId = table.Column<string>(nullable: true),
                                             ProductId = table.Column<int>(),
                                             Text = table.Column<string>(nullable: true),
                                             Rate = table.Column<int>(),
                                             Date = table.Column<DateTime>()
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Reviews", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_Reviews_Products_ProductId",
                                                              x => x.ProductId,
                                                              "Products",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_Reviews_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Restrict);
                                         });

            migrationBuilder.CreateIndex(
                                         "IX_AspNetRoleClaims_RoleId",
                                         "AspNetRoleClaims",
                                         "RoleId");

            migrationBuilder.CreateIndex(
                                         "RoleNameIndex",
                                         "AspNetRoles",
                                         "NormalizedName",
                                         unique: true,
                                         filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                                         "IX_AspNetUserClaims_UserId",
                                         "AspNetUserClaims",
                                         "UserId");

            migrationBuilder.CreateIndex(
                                         "IX_AspNetUserLogins_UserId",
                                         "AspNetUserLogins",
                                         "UserId");

            migrationBuilder.CreateIndex(
                                         "IX_AspNetUserRoles_RoleId",
                                         "AspNetUserRoles",
                                         "RoleId");

            migrationBuilder.CreateIndex(
                                         "EmailIndex",
                                         "AspNetUsers",
                                         "NormalizedEmail");

            migrationBuilder.CreateIndex(
                                         "UserNameIndex",
                                         "AspNetUsers",
                                         "NormalizedUserName",
                                         unique: true,
                                         filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                                         "IX_Products_CategoryId",
                                         "Products",
                                         "CategoryId");

            migrationBuilder.CreateIndex(
                                         "IX_Products_VendorId",
                                         "Products",
                                         "VendorId");

            migrationBuilder.CreateIndex(
                                         "IX_ProductsInCarts_OrderId",
                                         "ProductsInCarts",
                                         "OrderId");

            migrationBuilder.CreateIndex(
                                         "IX_ProductsInCarts_ProductId",
                                         "ProductsInCarts",
                                         "ProductId");

            migrationBuilder.CreateIndex(
                                         "IX_ProductsInCarts_UserId",
                                         "ProductsInCarts",
                                         "UserId");

            migrationBuilder.CreateIndex(
                                         "IX_Reviews_ProductId",
                                         "Reviews",
                                         "ProductId");

            migrationBuilder.CreateIndex(
                                         "IX_Reviews_UserId",
                                         "Reviews",
                                         "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                                       "AspNetRoleClaims");

            migrationBuilder.DropTable(
                                       "AspNetUserClaims");

            migrationBuilder.DropTable(
                                       "AspNetUserLogins");

            migrationBuilder.DropTable(
                                       "AspNetUserRoles");

            migrationBuilder.DropTable(
                                       "AspNetUserTokens");

            migrationBuilder.DropTable(
                                       "ProductsInCarts");

            migrationBuilder.DropTable(
                                       "Reviews");

            migrationBuilder.DropTable(
                                       "AspNetRoles");

            migrationBuilder.DropTable(
                                       "Orders");

            migrationBuilder.DropTable(
                                       "Products");

            migrationBuilder.DropTable(
                                       "AspNetUsers");

            migrationBuilder.DropTable(
                                       "Categories");

            migrationBuilder.DropTable(
                                       "Vendors");
        }
    }
}