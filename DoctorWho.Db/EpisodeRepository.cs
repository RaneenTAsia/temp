using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class EpisodeRepository
    {
        private DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public Episode CreateEpisode(Episode episode)
        {
            if ((_context.Episodes?.FindAsync(episode)) == null)
            {
                _context.Episodes.Add(episode);
                _context.SaveChangesAsync();
            }
            return episode;
        }
        public Episode UpdateEpisode(Episode episode)
        {
            if ((_context.Episodes?.FindAsync(episode)) == null)
            {
                throw new Exception("No Episode with this Id exists");
            }
            _context.Episodes.Update(episode);
            _context.SaveChangesAsync();

            return episode;
        }

        public void DeleteEpisode(Episode episode)
        {
            if ((_context.Episodes?.FindAsync(episode)) == null)
            {
                throw new Exception("No Episode with this Id exists");
            }
            _context.Episodes.Remove(episode);
            _context.SaveChangesAsync();
        }

        public void AddEnemyToEpisode(Enemy enemy, int episodeId)
        {
            var episodes = _context.Episodes.Include(e => e.Enemies);
            Episode? episode = episodes.SingleOrDefault(e => e.EpisodeId == episodeId);
            if (episode != null && _context.Enemies?.FindAsync(enemy) != null)
            {
                if (episode.Enemies.SingleOrDefault(enemy) == null)
                {
                    episode.Enemies.Add(enemy);
                    _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Episode already has this Enemy.");
                }
            }
        }

        public void AddCompanionToEpisode(Companion companion, int episodeId)
        {
            var episodes = _context.Episodes.Include(e => e.Enemies);
            Episode? episode = episodes.SingleOrDefault(e => e.EpisodeId == episodeId);
            if (episode != null && _context.Companions?.FindAsync(companion) != null)
            {
                if (episode.Companions.SingleOrDefault(companion) == null)
                {
                    episode.Companions.Add(companion);
                    _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Episode already has this companion.");
                }
            }
        }

    }
}
