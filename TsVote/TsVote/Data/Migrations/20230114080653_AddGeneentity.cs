using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TsVote.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Admi");

            migrationBuilder.EnsureSchema(
                name: "Gene");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "Admi");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Admi",
                table: "AspNetUsers",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Admi",
                table: "AspNetUsers",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "Admi",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                schema: "Admi",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Admi",
                table: "AspNetUsers",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Gene",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommuneTownships",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommuneTownships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommuneTownships_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Gene",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommuneTownships_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Gene",
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NeighborhoodSidewalks",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommuneTownshipId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighborhoodSidewalks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NeighborhoodSidewalks_CommuneTownships_CommuneTownshipId",
                        column: x => x.CommuneTownshipId,
                        principalSchema: "Gene",
                        principalTable: "CommuneTownships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "NeighborhoodSidewalkId");

            migrationBuilder.CreateIndex(
                name: "IX_City_State_Name",
                schema: "Gene",
                table: "Cities",
                columns: new[] { "StateId", "Name" },
                unique: true,
                filter: "[StateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommuneTownship_City_Zone_Name",
                schema: "Gene",
                table: "CommuneTownships",
                columns: new[] { "CityId", "ZoneId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommuneTownships_ZoneId",
                schema: "Gene",
                table: "CommuneTownships",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                schema: "Gene",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Name",
                schema: "Gene",
                table: "Genders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NeighborhoodSidewalk_CommuneTownship_Name",
                schema: "Gene",
                table: "NeighborhoodSidewalks",
                columns: new[] { "CommuneTownshipId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_State_Country_Name",
                schema: "Gene",
                table: "States",
                columns: new[] { "CountryId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zone_Name",
                schema: "Gene",
                table: "Zones",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "GenderId",
                principalSchema: "Gene",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_NeighborhoodSidewalks_NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "NeighborhoodSidewalkId",
                principalSchema: "Gene",
                principalTable: "NeighborhoodSidewalks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_NeighborhoodSidewalks_NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "NeighborhoodSidewalks",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "CommuneTownships",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Zones",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "States",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Gene");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Admi",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Admi",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Admi",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Admi",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Admi",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Admi",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Admi",
                newName: "AspNetRoleClaims");
        }
    }
}
