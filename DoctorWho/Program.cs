using System.Data;
using System.Net;
using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho
{
    public class Program
    {
        DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        static void Main(string[] args)
        {
            using (var context = new DoctorWhoCoreDbContext())
            {
                GetCompanionsFromEpisodeData(1, context);
                GetEnemiesFromEpisodeData(1,context);
                GetEpisodeViewData(context);
                GetEpisodesSummaryData(context);
            }
            
        }

        private static void GetEpisodesSummaryData(DoctorWhoCoreDbContext context)
        {
            List<Companion> companions = new List<Companion>();
            List<Enemy> enemies = new List<Enemy>();

            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "[dbo].spSummariseEpisodes";

            try
            {
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    companions.Add(new Companion { CompanionName = reader.GetString("Companion") });
                }
                reader.NextResult();

                while (reader.Read())
                {
                    enemies.Add(new Enemy { EnemyName = reader.GetString("Enemy") });
                }

                Console.WriteLine("Top Three Companions");
                foreach (var companion in companions) Console.WriteLine(companion.CompanionName);
                Console.WriteLine("\nTop Three Enemies");
                foreach(var enemy in enemies) Console.WriteLine(enemy.EnemyName);
            }
            finally
            {
                cmd.Connection?.Close();
            }
        }

        private static void GetEpisodeViewData(DoctorWhoCoreDbContext context)
        {
            var result = context.ViewEpisodes.ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString()+"\n");
            }
        }

        private static void GetEnemiesFromEpisodeData(int episodeId, DoctorWhoCoreDbContext context)
        {
            var result = context.Episodes
                .Where(e => e.EpisodeId == episodeId)
                .Select
                (a => context.FnEnemiesResult(episodeId)
                ).Single().ToString();
            Console.WriteLine(result);
        }

        private static void GetCompanionsFromEpisodeData(int episodeId, DoctorWhoCoreDbContext context)
        {
            var result = context.Episodes
                .Where(e => e.EpisodeId == episodeId)
                .Select
                (a => context.FnCompanionsResult(episodeId)
                ).Single().ToString();
            Console.WriteLine(result);
        }
    }
}