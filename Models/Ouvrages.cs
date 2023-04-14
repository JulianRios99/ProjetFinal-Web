namespace ProjetFinal.Models
{
    public class Ouvrages
    {
        public int ID { get; set; }
        public required string titre { get; set; }

        //Voir si auteur devrait etre dans un enum
        public required string auteur { get; set; }

        public required int exemplaires { get; set; }
    }
}
