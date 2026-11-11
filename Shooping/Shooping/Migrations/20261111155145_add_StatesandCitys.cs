using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shooping.Migrations
{
    /// <inheritdoc />
    public partial class add_StatesandCitys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Estates_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Countries_CountryId",
                table: "Estates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estates",
                table: "Estates");

            migrationBuilder.RenameTable(
                name: "Estates",
                newName: "States");

            migrationBuilder.RenameIndex(
                name: "IX_Estates_Name_CountryId",
                table: "States",
                newName: "IX_States_Name_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Estates_CountryId",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "Estates");

            migrationBuilder.RenameIndex(
                name: "IX_States_Name_CountryId",
                table: "Estates",
                newName: "IX_Estates_Name_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                table: "Estates",
                newName: "IX_Estates_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estates",
                table: "Estates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Estates_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_Countries_CountryId",
                table: "Estates",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
