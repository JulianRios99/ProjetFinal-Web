namespace ProjetFinal.Models
{
    public class Reservations
    {
        public int ID  { get; set; } 
        public required Utilisateurs Utilisateurs { get; set; }
        public required Ouvrages Ouvrage { get; set; }

       
    }
}
