using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class initialseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanionEpisode_episodes_EpisodesEpisodeId",
                table: "CompanionEpisode");

            migrationBuilder.DropForeignKey(
                name: "FK_EnemyEpisode_episodes_EpisodesEpisodeId",
                table: "EnemyEpisode");

            migrationBuilder.DropForeignKey(
                name: "FK_episodes_Authors_AuthorId",
                table: "episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_episodes_Doctors_DoctorId",
                table: "episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_episodes",
                table: "episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnemyEpisode",
                table: "EnemyEpisode");

            migrationBuilder.DropIndex(
                name: "IX_EnemyEpisode_EpisodesEpisodeId",
                table: "EnemyEpisode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanionEpisode",
                table: "CompanionEpisode");

            migrationBuilder.RenameTable(
                name: "episodes",
                newName: "Episodes");

            migrationBuilder.RenameIndex(
                name: "IX_episodes_DoctorId",
                table: "Episodes",
                newName: "IX_Episodes_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_episodes_AuthorId",
                table: "Episodes",
                newName: "IX_Episodes_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Episodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SeriesNumber",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Null",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EpisodeType",
                table: "Episodes",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EpisodeNumber",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EpisodeDate",
                table: "Episodes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Episodes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EnemyName",
                table: "Enemies",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEpisodeDate",
                table: "Doctors",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstEpisodeDate",
                table: "Doctors",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorName",
                table: "Doctors",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Doctors",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "WhoPlayed",
                table: "Companions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanionName",
                table: "Companions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Authors",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes",
                column: "EpisodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnemyEpisode",
                table: "EnemyEpisode",
                columns: new[] { "EpisodesEpisodeId", "EnemiesEnemyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanionEpisode",
                table: "CompanionEpisode",
                columns: new[] { "EpisodesEpisodeId", "CompanionsCompanionId" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Rayyan Asia" },
                    { 2, "Raneen Asia" },
                    { 3, "Rami Asia" },
                    { 4, "Reema Asia" },
                    { 5, "Karam Shawish" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Dr. Grace Hollow", "Daphne Ashbrook" },
                    { 2, "Elizabeth Shaw", "Caroline John" },
                    { 3, "Ace", "Sophie Aldred" },
                    { 4, "Captain Mike Yates", "Richard Franklin" },
                    { 5, "Melanie", "Bonnie Langford" },
                    { 6, "TuTu", "Tawfieg" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Tennant", 1, new DateTime(2010, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1990, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matt Smith", 2, new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1985, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter Capaldi", 3, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1992, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher Eccleston", 4, new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1990, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jodie Whittaker", 5, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "Fellow Time Lord that constantly tries to torment and destroy the doctor.", "The Master" },
                    { 2, "Beings that chased The Doctor for near immortality.", "Family of Blood" },
                    { 3, "These robots have plagued the Doctor for centuries.", "Daleks" },
                    { 4, "Emotionless robots from another world that constantly change their design, becoming more powerful, and upgrading every time we see them.", "Cybermen" },
                    { 5, "Horrifying stone statues that have a pretty scary design, but the real fear is how these creatures move and kill their prey.", "Weeping Angels" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2010, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Comedy,Eerie", "The Best Doctor IMO", 1, "Pilot" },
                    { 2, 2, 2, new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Comedy,Eerie,Investigation", "Longest Production Episode", 2, "The Second Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 3, 3, 3, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Comedy,Action", 3, "Back to the Booth" },
                    { 4, 4, 4, new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Comedy,Detective", 4, "Another Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 5, 5, 5, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Comedy,Eerie", "New Cast Who Dis?", 5, "Time Is Not So Simple" },
                    { 6, 1, null, new DateTime(2010, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Comedy,Eerie", "No Doctor", 1, "Our Fist Encounter" }
                });

            migrationBuilder.InsertData(
                table: "CompanionEpisode",
                columns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "EnemyEpisode",
                columns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnemyEpisode_EnemiesEnemyId",
                table: "EnemyEpisode",
                column: "EnemiesEnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanionEpisode_CompanionsCompanionId",
                table: "CompanionEpisode",
                column: "CompanionsCompanionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanionEpisode_Episodes_EpisodesEpisodeId",
                table: "CompanionEpisode",
                column: "EpisodesEpisodeId",
                principalTable: "Episodes",
                principalColumn: "EpisodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnemyEpisode_Episodes_EpisodesEpisodeId",
                table: "EnemyEpisode",
                column: "EpisodesEpisodeId",
                principalTable: "Episodes",
                principalColumn: "EpisodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Authors_AuthorId",
                table: "Episodes",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Doctors_DoctorId",
                table: "Episodes",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanionEpisode_Episodes_EpisodesEpisodeId",
                table: "CompanionEpisode");

            migrationBuilder.DropForeignKey(
                name: "FK_EnemyEpisode_Episodes_EpisodesEpisodeId",
                table: "EnemyEpisode");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Authors_AuthorId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Doctors_DoctorId",
                table: "Episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnemyEpisode",
                table: "EnemyEpisode");

            migrationBuilder.DropIndex(
                name: "IX_EnemyEpisode_EnemiesEnemyId",
                table: "EnemyEpisode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanionEpisode",
                table: "CompanionEpisode");

            migrationBuilder.DropIndex(
                name: "IX_CompanionEpisode_CompanionsCompanionId",
                table: "CompanionEpisode");

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "Episodes",
                newName: "episodes");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_DoctorId",
                table: "episodes",
                newName: "IX_episodes_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_AuthorId",
                table: "episodes",
                newName: "IX_episodes_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "episodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "SeriesNumber",
                table: "episodes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "episodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Null");

            migrationBuilder.AlterColumn<string>(
                name: "EpisodeType",
                table: "episodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<int>(
                name: "EpisodeNumber",
                table: "episodes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EpisodeDate",
                table: "episodes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "episodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnemyName",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEpisodeDate",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstEpisodeDate",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<string>(
                name: "WhoPlayed",
                table: "Companions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "CompanionName",
                table: "Companions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddPrimaryKey(
                name: "PK_episodes",
                table: "episodes",
                column: "EpisodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnemyEpisode",
                table: "EnemyEpisode",
                columns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanionEpisode",
                table: "CompanionEpisode",
                columns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" });

            migrationBuilder.CreateIndex(
                name: "IX_EnemyEpisode_EpisodesEpisodeId",
                table: "EnemyEpisode",
                column: "EpisodesEpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanionEpisode_episodes_EpisodesEpisodeId",
                table: "CompanionEpisode",
                column: "EpisodesEpisodeId",
                principalTable: "episodes",
                principalColumn: "EpisodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnemyEpisode_episodes_EpisodesEpisodeId",
                table: "EnemyEpisode",
                column: "EpisodesEpisodeId",
                principalTable: "episodes",
                principalColumn: "EpisodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_Authors_AuthorId",
                table: "episodes",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_Doctors_DoctorId",
                table: "episodes",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
