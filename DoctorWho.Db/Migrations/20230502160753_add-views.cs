using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class addviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
             create view viewEpisodes as
             select a.AuthorName, d.DoctorName, dbo.fnCompanions(e.EpisodeId) as 'Companions',
                dbo.fnEnemies(e.EpisodeId) as 'Enemies'
             from Episodes e
             LEFT JOIN Authors a on e.AuthorId = a.AuthorId
             LEFT JOIN Doctors d on e.DoctorId = d.DoctorId;
             ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW viewEpisodes");
        }
    }
}
