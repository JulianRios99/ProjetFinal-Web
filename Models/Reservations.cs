namespace ProjetFinal.Models
{
    public class Reservations
    {
        public int EnseignantID { get; set; }
        public int CoursID { get; set; }
        public required Utilisateurs utilisateur { get; set; }
        public required Ouvrages ouvrage { get; set; }

        public List<Utilisateurs> utilisateurs { get; set; } = new();
    }
}
