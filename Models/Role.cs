namespace ProjetFinal.Models
{
    public class Role
    {
        public  int ID { get; set; }
        public required string Nom { get; set; }

        public List<Utilisateurs> Utilisateurs { get; set; } = new();
    }
}
