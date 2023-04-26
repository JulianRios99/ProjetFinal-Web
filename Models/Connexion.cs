using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetFinal.Models
{
    public class Connexion
    {
        [EmailAddress]
        public required string Courriel { get; set; }

        [Column(TypeName = "varbinary(max)"), Display(Name = "Mot de passe"), DataType(DataType.Password)]
        public required string MotDePasse { get; set; }
    }
}
