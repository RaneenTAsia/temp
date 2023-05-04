using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class EnemyEpisode
    {
        [Column("EnemiesEnemyId")]
        public int EnemyId { get; set; }
        public Enemy Enemy { get; set; }
        [Column("EpisodesEpisodeId")]
        public int EpisodeId { get; set; }
        public Episode Episode { get; set;}
    }
}
