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
        public required string Prenom { get; set; }
        public required string Nom { get; set; }

        [EmailAddress]
        public required string Courriel { get; set; }

        [Column(TypeName = "varbinary(max)"), Display(Name = "Mot de passe"), DataType(DataType.Password)]
        public required string MotDePasse { get; set; }

        public required Langue Langue { get; set; }

        //Voir si besoin de roles
        public required bool Admin { get; set; }

        public List<Reservations> Reservations { get; set; } = new();
         public List<Role> Roles { get; set; } = new();

    }
}
