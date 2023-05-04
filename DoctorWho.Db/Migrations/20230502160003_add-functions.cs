using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class addfunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create function dbo.fnCompanions (@EpisodeId INT)
                returns varchar(MAX) as
                begin
                	Declare @episodeCompanions varchar(MAX) ='';
                	Select  @episodeCompanions = @episodeCompanions + c.CompanionName + ', '
                	from Companions c
                	JOIN CompanionEpisode ec ON c.CompanionId = ec.CompanionsCompanionId 
                	where ec.EpisodesEpisodeId = @EpisodeId
                	
                	-- to remove any commas at the end
                	IF LEN(@episodeCompanions) > 0
                        SET @episodeCompanions = LEFT(@episodeCompanions, LEN(@episodeCompanions) - 1);
	
	                return @episodeCompanions
                end;
            ");

            migrationBuilder.Sql(@"
             create function dbo.fnEnemies (@EpisodeId INT)
             returns varchar(MAX) as
             begin
	            Declare @episodeEnemies varchar(MAX) ='';
	            Select  @episodeEnemies = @episodeEnemies + e.EnemyName + ', '
	            from Enemies e
	            JOIN EnemyEpisode ee ON e.EnemyId = ee.EnemiesEnemyId 
	            where ee.EpisodesEpisodeId = @EpisodeId
	
	            -- to remove any commas at the end
                IF LEN(@episodeEnemies) > 0
                SET @episodeEnemies = LEFT(@episodeEnemies, LEN(@episodeEnemies) - 1);
                
                return @episodeEnemies
             end;
            ");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP FUNCTION dbo.fnCompanions");
            migrationBuilder.Sql($"DROP FUNCTION dbo.fnEnemies");
        }
    }
}
