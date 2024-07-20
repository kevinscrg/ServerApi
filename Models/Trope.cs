namespace ServerApi.Models
{
    public class Trope
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public List<Carte> Carti { get; set; }
    }
}
