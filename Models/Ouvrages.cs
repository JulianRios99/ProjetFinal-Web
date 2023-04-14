namespace ProjetFinal.Models
{
    public class Ouvrages
    {
        public int ID { get; set; }
        public required string Titre { get; set; }

        public required string Auteur { get; set; }

        public required int Exemplaires { get; set; }

        public List<Reservations> Reservations { get; set; } = new();
    }
}
