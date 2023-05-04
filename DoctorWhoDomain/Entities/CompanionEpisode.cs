using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public  class CompanionEpisode
    {
        [Column("CompanionsCompanionId")]
        public int CompanionId { get; set; }
        public Companion Companion { get; set; }

        [Column("EpisodesEpisodeId")]
        public int EpisodeId { get; set;}
        public Episode Episode { get; set; }
    }
}
