using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArquitecture.Data.Migrations
{
    public partial class CleanArchitecture1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VideosActores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VideosActores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VideosActores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "VideosActores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "VideosActores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Videos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Videos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Streamers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Streamers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Streamers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Streamers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Directores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Directores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Directores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Directores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Actores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Actores",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Actores");
        }
    }
}
