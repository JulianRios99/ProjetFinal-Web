using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Donnees
{
    public static class DonneesTest
    {
        public async static Task Charger(Bibliotheque bibliotheque)
        {
            await bibliotheque.Database.MigrateAsync();

            if (await bibliotheque.Ouvrages.AnyAsync())
            {
                return;
            }


            var roleAdmin = new Role { Nom = "Admin" };
            var roleUser = new Role { Nom = "User" };

            await bibliotheque.Roles.AddRangeAsync(new Role[] { roleAdmin, roleUser });

            var henri = (await bibliotheque.Utilisateurs.FromSql($@"
            INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
            OUTPUT INSERTED.ID,
                   INSERTED.Prenom,
                   INSERTED.Nom,
                   INSERTED.Courriel,
                   INSERTED.MotDePasse,
                   INSERTED.Langue,
                   INSERTED.Admin,
            VALUES ({"Henry"},{"Delpech"}, {"henry.delpech@gmail.com"}, HASHBYTES('SHA2_256, {"test1"}), {0}, {"false"})
            ").ToListAsync())[0];


            var anais = (await bibliotheque.Utilisateurs.FromSql($@"
            INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
            OUTPUT INSERTED.ID,
                   INSERTED.Prenom,
                   INSERTED.Nom,
                   INSERTED.Courriel,
                   INSERTED.MotDePasse,
                   INSERTED.Langue,
                   INSERTED.Admin,
            VALUES ({"Anaïs"},{"Laventure"}, {"anais.laventure@gmail.com"}, HASHBYTES('SHA2_256, {"test2"}), {0}, {"true"})
            ").ToListAsync())[0];


            var felix = (await bibliotheque.Utilisateurs.FromSql($@"
            INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
            OUTPUT INSERTED.ID,
                   INSERTED.Prenom,
                   INSERTED.Nom,
                   INSERTED.Courriel,
                   INSERTED.MotDePasse,
                   INSERTED.Langue,
                   INSERTED.Admin,
            VALUES ({"Félix"},{"Dionne"}, {"felix.dionne@gmail.com"}, HASHBYTES('SHA2_256, {"test3"}), {0}, {"false"})
            ").ToListAsync())[0];

            var michel = (await bibliotheque.Utilisateurs.FromSql($@"
            INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
            OUTPUT INSERTED.ID,
                   INSERTED.Prenom,
                   INSERTED.Nom,
                   INSERTED.Courriel,
                   INSERTED.MotDePasse,
                   INSERTED.Langue,
                   INSERTED.Admin,
            VALUES ({"Michel"},{"Toussaint"}, {"toussaint.michel@gmail.com"}, HASHBYTES('SHA2_256, {"test4"}), {0}, {"false"})
            ").ToListAsync())[0];

            var kinza = (await bibliotheque.Utilisateurs.FromSql($@"
            INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
            OUTPUT INSERTED.ID,
                   INSERTED.Prenom,
                   INSERTED.Nom,
                   INSERTED.Courriel,
                   INSERTED.MotDePasse,
                   INSERTED.Langue,
                   INSERTED.Admin,
            VALUES ({"Kinza"},{"Bacha"}, {"kinza.bacha@gmail.com"}, HASHBYTES('SHA2_256, {"test5"}), {0}, {"false"})
            ").ToListAsync())[0];


            var Jian = (await bibliotheque.Utilisateurs.FromSql($@"
            INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
            OUTPUT INSERTED.ID,
                   INSERTED.Prenom,
                   INSERTED.Nom,
                   INSERTED.Courriel,
                   INSERTED.MotDePasse,
                   INSERTED.Langue,
                   INSERTED.Admin,
            VALUES ({"Jian"},{"Xiaochun"}, {"jian.xiaochun@gmail.com"}, HASHBYTES('SHA2_256, {"test6"}), {1}, {"false"})
            ").ToListAsync())[0];


            henri.Role.Add(roleUser);
            anais.Role.Add(roleAdmin);
            felix.Role.Add(roleUser);
            michel.Role.Add(roleUser);
            kinza.Role.Add(roleUser);
            Jian.Role.Add(roleUser);


            var ouvrage1 = new Ouvrages()
            { 
                Titre = "Stupeur et Tremblements",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1
            
            };

            var ouvrage2 = new Ouvrages()
            {
                Titre = "Une forme de vie",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1

            };

            var ouvrage3 = new Ouvrages()
            {
                Titre = "Barbe blue",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1

            };

            var ouvrage4 = new Ouvrages()
            {
                Titre = "Journal d'Hirondelle",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1

            };

            var ouvrage5 = new Ouvrages()
            {
                Titre = "Journal d'Hirondelle",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1

            };

            //------ continuer les ouvrage (son 22)

            await bibliotheque.Ouvrages.AddRangeAsync(new Ouvrages[] { ouvrage1, ouvrage2, ouvrage3, ouvrage4, ouvrage5 }); // continuar agregando los ouvrages 



            var reservation1 = new Reservations()
            {
                Utilisateurs = michel,
                Ouvrage = ouvrage1  // MODIFIER louvrage correct est la 10 
            };

            /*
            var reservation2 = new Reservations()
            {
                Utilisateurs = michel,
                Ouvrage = ouvrage1,  // MODIFIER louvrage correct est la 10 
            };*/

            var reservation3 = new Reservations()
            {
                Utilisateurs = felix,
                Ouvrage = ouvrage1 // MODIFIER louvrage correct est la 6
            };


            var reservation4 = new Reservations()
            {
                Utilisateurs = anais,
                Ouvrage = ouvrage4
               
            };


            var reservation5 = new Reservations()
            {
                Utilisateurs = kinza,
                Ouvrage = ouvrage3 // MODIFIER louvrage correct est la 6
            };

            await bibliotheque.Reservations.AddRangeAsync(new Reservations[] { reservation1, reservation3, reservation4, reservation5 }); // MODIFIER LES RESERVATIONS

            await bibliotheque.SaveChangesAsync();

        }

    }

}
