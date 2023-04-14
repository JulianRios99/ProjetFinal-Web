using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal.Models
{
    public enum Langue
    {
        Francais,
        Anglais
    }

    public class Utilisateurs
    {
        public int ID { get; set; }
        public required string prenom { get; set; }
        public required string nom { get; set; }

        [EmailAddress]
        public required string courriel { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public required string motDePasse { get; set; }

        public required Langue langue { get; set; }

        //Voir si besoin de roles
        public required bool admin { get; set; }

    }
}
