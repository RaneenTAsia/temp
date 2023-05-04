namespace DoctorWho.Db
{
    public class Enemy
    {
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }

        public List<Episode> Episodes { get; set; }

        public Enemy()
        {
            Episodes = new List<Episode>();
        }
    }
}