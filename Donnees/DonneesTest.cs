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
                Titre = "Acide Sulfurique",
                Auteur = "Amelie Nothomb",
                Exemplaires = 2

            };

            var ouvrage6 = new Ouvrages()
            {
                Titre = "Le mystère par excellence",
                Auteur = "Amelie Nothomb",
                Exemplaires = 2

            };

            var ouvrage7 = new Ouvrages()
            {
                Titre = "Le Sabotage amoureux",
                Auteur = "Amelie Nothomb",
                Exemplaires = 2

            };

            var ouvrage8 = new Ouvrages()
            {
                Titre = "Le voyage d'hiver",
                Auteur = "Amelie Nothomb",
                Exemplaires = 2

            };

            var ouvrage9 = new Ouvrages()
            {
                Titre = "Les catalinaires",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1

            };


            var ouvrage10 = new Ouvrages()
            {
                Titre = "Métaphysique Des Tubes",
                Auteur = "Amelie Nothomb",
                Exemplaires = 3

            };

            var ouvrage11 = new Ouvrages()
            {
                Titre = "Premier bilan après l’apocalypse",
                Auteur = "Frédéric Beigbeder",
                Exemplaires = 1

            };


            var ouvrage12 = new Ouvrages()
            {
                Titre = "Au secours pardon",
                Auteur = "Frédéric Beigbeder",
                Exemplaires = 1

            };



            var ouvrage13 = new Ouvrages()
            {
                Titre = "Un roman français",
                Auteur = "Frédéric Beigbeder",
                Exemplaires = 1

            };

            var ouvrage14 = new Ouvrages()
            {
                Titre = "Mémoires D'Un Jeune Homme Dérangé ",
                Auteur = "Frédéric Beigbeder",
                Exemplaires = 1

            };


            var ouvrage15 = new Ouvrages()
            {
                Titre = "99 Francs",
                Auteur = "Frédéric Beigbeder",
                Exemplaires = 2

            };

            var ouvrage16 = new Ouvrages()
            {
                Titre = "L'homme qui pleure de rire",
                Auteur = "Frédéric Beigbeder",
                Exemplaires = 2

            };

            var ouvrage17 = new Ouvrages()
            {
                Titre = "Vacances dans le coma",
                Auteur = "Frédéric Beigbeder",
                Exemplaires = 1

            };

            var ouvrage18 = new Ouvrages()
            {
                Titre = "La frivolité est une affaire sérieuse ",
                Auteur = "Frédéric Beigbeder",
                Exemplaires = 1

            };

            var ouvrage19 = new Ouvrages()
            {
                Titre = "La petite Chose",
                Auteur = "Alphonse Daudet",
                Exemplaires = 1

            };

            var ouvrage20 = new Ouvrages()
            {
                Titre = "Les lettres de mon moulin",
                Auteur = "Alphonse Daudet",
                Exemplaires = 2

            };

            var ouvrage21 = new Ouvrages()
            {
                Titre = "Tartarin sur les Alpes",
                Auteur = "Alphonse Daudet",
                Exemplaires = 2

            };


            var ouvrage22 = new Ouvrages()
            {
                Titre = "Tartarin sur les Alpes",
                Auteur = "Alphonse Daudet",
                Exemplaires = 2

            };

            
            await bibliotheque.Ouvrages.AddRangeAsync(new Ouvrages[] { ouvrage1, ouvrage2, ouvrage3, ouvrage4, ouvrage5, ouvrage6, ouvrage7, ouvrage8, ouvrage9, ouvrage10,
                ouvrage11, ouvrage12, ouvrage13, ouvrage14, ouvrage15, ouvrage16, ouvrage17, ouvrage18, ouvrage19, ouvrage20, ouvrage21, ouvrage22 });



            var reservation1 = new Reservations()
            {
                Utilisateurs = michel,
                Ouvrage = ouvrage10  // Il manque ajouter lautre 
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
                Ouvrage = ouvrage6
            };


            var reservation4 = new Reservations()
            {
                Utilisateurs = anais,
                Ouvrage = ouvrage4    
            };


            var reservation5 = new Reservations()
            {
                Utilisateurs = kinza,

              //  Ouvrage = List<Ouvrages>(ouvrage20, ouvrage3)

                Ouvrage = ouvrage20 // il manque ajouter l'ouvrage3 
            };

            await bibliotheque.Reservations.AddRangeAsync(new Reservations[] { reservation1, reservation3, reservation4, reservation5 }); // MODIFIER LES RESERVATIONS

            await bibliotheque.SaveChangesAsync();

        }

    }

}
