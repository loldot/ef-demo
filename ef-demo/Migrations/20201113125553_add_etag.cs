using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ef_demo.Migrations
{
    public partial class add_etag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Etag",
                table: "Games",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Etag",
                table: "Games");
        }
    }
}
