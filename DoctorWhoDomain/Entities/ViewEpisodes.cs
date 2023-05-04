namespace DoctorWhoDomain
{
    public class ViewEpisodes
    {
        
        public string? AuthorName { get; set; }
        public string? DoctorName { get; set; } 

        public string? Companions { get; set; }
        public string? Enemies { get; set; }

        public override string ToString()
        {
            return $"Author Name: {AuthorName}, Doctor: {DoctorName}\nCompanions: {Companions}\nEnemies: {Enemies}";
        }

    }
}