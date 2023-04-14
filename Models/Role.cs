namespace ProjetFinal.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Nom { get; set; }

        public List<Utilisateurs> Utilisateurs { get; set; } = new();
    }
}
