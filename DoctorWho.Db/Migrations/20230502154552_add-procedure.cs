using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class addprocedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
             create procedure dbo.spSummariseEpisodes
             as 
             begin
	            select top 3 c.CompanionName as 'Companion', Count(ec.CompanionsCompanionId) as 'Appearance Count'
	            from Companions c left join CompanionEpisode ec on c.CompanionId = ec.CompanionsCompanionId
	            group by c.CompanionName
            	order by Count(ec.CompanionsCompanionId) Desc;
            
            	select top 3 e.EnemyName as 'Enemy', COUNT(ee.EnemiesEnemyId) as 'Appearance Count'
                from Enemies e
                LEFT JOIN EnemyEpisode ee on e.EnemyId = ee.EnemiesEnemyId
                group by e.EnemyName
                order by COUNT(ee.EnemiesEnemyId) desc;

                end;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.spSummariseEpisodes");
        }
    }
}
