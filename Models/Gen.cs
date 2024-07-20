namespace ServerApi.Models
{
    public class Gen
    {
        public int Id { get; set; }
        public string? Nume { get; set; } 
        public List<Carte> Carti { get; set; } = new List<Carte>();
    }
}
