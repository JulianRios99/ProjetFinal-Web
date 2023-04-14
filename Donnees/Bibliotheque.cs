using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Donnees
{
    public class Bibliotheque: DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddSimpleConsole());

        public DbSet<Ouvrages> Ouvrages { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Utilisateurs> Utilisateurs { get;set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(Bibliotheque.loggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer("Server=.; Database=ProjetFinalWeb; Encrypt=False; Trusted_Connection=True;");
        }
    }
}
