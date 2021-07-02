using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhereToEat.MVC.Data.Migrations
{
    public partial class AddsChoiceGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChoiceGroups",
                columns: table => new
                {
                    ChoiceGroupId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceGroups", x => x.ChoiceGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceGroupRestaurant",
                columns: table => new
                {
                    ChoiceGroupsChoiceGroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PotentialRestaurantsRestaurantId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceGroupRestaurant", x => new { x.ChoiceGroupsChoiceGroupId, x.PotentialRestaurantsRestaurantId });
                    table.ForeignKey(
                        name: "FK_ChoiceGroupRestaurant_ChoiceGroups_ChoiceGroupsChoiceGroupId",
                        column: x => x.ChoiceGroupsChoiceGroupId,
                        principalTable: "ChoiceGroups",
                        principalColumn: "ChoiceGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoiceGroupRestaurant_Restaurants_PotentialRestaurantsRestaurantId",
                        column: x => x.PotentialRestaurantsRestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceMembers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ChoiceGroupId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceMembers", x => new { x.UserId, x.ChoiceGroupId });
                    table.ForeignKey(
                        name: "FK_ChoiceMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoiceMembers_ChoiceGroups_ChoiceGroupId",
                        column: x => x.ChoiceGroupId,
                        principalTable: "ChoiceGroups",
                        principalColumn: "ChoiceGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceMemberRestaurant",
                columns: table => new
                {
                    DislikedRestaurantsRestaurantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChoiceMembersUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ChoiceMembersChoiceGroupId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceMemberRestaurant", x => new { x.DislikedRestaurantsRestaurantId, x.ChoiceMembersUserId, x.ChoiceMembersChoiceGroupId });
                    table.ForeignKey(
                        name: "FK_ChoiceMemberRestaurant_ChoiceMembers_ChoiceMembersUserId_ChoiceMembersChoiceGroupId",
                        columns: x => new { x.ChoiceMembersUserId, x.ChoiceMembersChoiceGroupId },
                        principalTable: "ChoiceMembers",
                        principalColumns: new[] { "UserId", "ChoiceGroupId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoiceMemberRestaurant_Restaurants_DislikedRestaurantsRestaurantId",
                        column: x => x.DislikedRestaurantsRestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceGroupRestaurant_PotentialRestaurantsRestaurantId",
                table: "ChoiceGroupRestaurant",
                column: "PotentialRestaurantsRestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceMemberRestaurant_ChoiceMembersUserId_ChoiceMembersChoiceGroupId",
                table: "ChoiceMemberRestaurant",
                columns: new[] { "ChoiceMembersUserId", "ChoiceMembersChoiceGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceMembers_ChoiceGroupId",
                table: "ChoiceMembers",
                column: "ChoiceGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoiceGroupRestaurant");

            migrationBuilder.DropTable(
                name: "ChoiceMemberRestaurant");

            migrationBuilder.DropTable(
                name: "ChoiceMembers");

            migrationBuilder.DropTable(
                name: "ChoiceGroups");
        }
    }
}
