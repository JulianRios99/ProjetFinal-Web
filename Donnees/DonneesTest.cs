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

            //USERS!
            var henry = new Utilisateurs()
            {
                prenom = "Henri",
                nom = "Delpech",
                courriel = "henri.delpech@gmail.com",
                //voir c'est correct ca:
                motDePasse = $@"HASHBYTES('SHA2_256', { "test1" })",
                langue = Langue.Francais,
                admin = false
            };

            var anais = new Utilisateurs()
            {
                prenom = "Anais",
                nom = "Laventure",
                courriel = "anais.laventure@gmail.com",
                //voir c'est correct ca:
                motDePasse = $@"HASHBYTES('SHA2_256', {"test2"})",
                langue = Langue.Francais,
                admin = true
            };

            var felix = new Utilisateurs()
            {
                prenom = "Felix",
                nom = "Dionne",
                courriel = "felix.dionne@gmail.com",
                //voir c'est correct ca:
                motDePasse = $@"HASHBYTES('SHA2_256', {"test3"})",
                langue = Langue.Francais,
                admin = false
            };

            var toussaint = new Utilisateurs()
            {
                prenom = "Toussaint",
                nom = "Michel",
                courriel = "toussaint.michel@gmail.com",
                //voir c'est correct ca:
                motDePasse = $@"HASHBYTES('SHA2_256', {"test4"})",
                langue = Langue.Francais,
                admin = false
            };

            var kinza = new Utilisateurs()
            {
                prenom = "Kinza",
                nom = "Bacha",
                courriel = "kinza.bacha@gmail.com",
                //voir c'est correct ca:
                motDePasse = $@"HASHBYTES('SHA2_256', {"test5"})",
                langue = Langue.Francais,
                admin = false
            };

            var jian = new Utilisateurs()
            {
                prenom = "Jian",
                nom = "Xiaochun",
                courriel = "jian.xiaochun@gmail.com",
                //voir c'est correct ca:
                motDePasse = $@"HASHBYTES('SHA2_256', {"test6"})",
                langue = Langue.Anglais,
                admin = false
            };


            //BOOKS!
            var stupeurTremblements = new Ouvrages()
            {
                titre = "Stupeur Et Tremblements",
                auteur = "Amelie Nothomb",
                exemplaires = 1
            };

            var formVie = new Ouvrages()
            {
                titre = "Une forme de vie",
                auteur = "Amelie Nothomb",
                exemplaires = 1
            };

            var barbeBleue = new Ouvrages()
            {
                titre = "Barbe bleue",
                auteur = "Amelie Nothomb",
                exemplaires = 1
            };

            var journalHirondelle = new Ouvrages()
            {
                titre = "Journal d'Hirondelle",
                auteur = "Amelie Nothomb",
                exemplaires = 1
            };

            var acideSulfurique = new Ouvrages()
            {
                titre = "Acide Sulfurique",
                auteur = "Amelie Nothomb",
                exemplaires = 2
            };

            var mystereExcellence = new Ouvrages()
            {
                titre = "Le Mystere par excellence",
                auteur = "Amelie Nothomb",
                exemplaires = 2
            };

            var sabotageAmoureux = new Ouvrages()
            {
                titre = "Le Sabotage amoureux",
                auteur = "Amelie Nothomb",
                exemplaires = 2
            };

            var voyageHiver = new Ouvrages()
            {
                titre = "Le Voyage d'hiver",
                auteur = "Amelie Nothomb",
                exemplaires = 2
            };

            var lesCatilinaires = new Ouvrages()
            {
                titre = "Les Catilinaires",
                auteur = "Amelie Nothomb",
                exemplaires = 1
            };

            var metaphysique = new Ouvrages()
            {
                titre = "Methaphysique Des Tubes",
                auteur = "Amelie Nothomb",
                exemplaires = 3
            };

            var premierApocalypse = new Ouvrages()
            {
                titre = "Premier bilan apres l'apocalypse",
                auteur = "Frederic Beigbeder",
                exemplaires = 1
            };

            var secoursPardon = new Ouvrages()
            {
                titre = "Au secours pardon",
                auteur = "Frederic Beigbeder",
                exemplaires = 1
            };

            var romanFrancais = new Ouvrages()
            {
                titre = "Un roman francais",
                auteur = "Frederic Beigbeder",
                exemplaires = 1
            };

            var memoiresDeranges = new Ouvrages()
            {
                titre = "Memoires D'Un Jeune Homme Derange",
                auteur = "Frederic Beigbeder",
                exemplaires = 1
            };

            var francs = new Ouvrages()
            {
                titre = "99 Francs",
                auteur = "Frederic Beigbeder",
                exemplaires = 1
            };

            var hommePleure = new Ouvrages()
            {
                titre = "L'Homme qui pleure de rire",
                auteur = "Frederic Beigbeder",
                exemplaires = 2
            };

            var vacancesComa = new Ouvrages()
            {
                titre = "Vacances dans le coma",
                auteur = "Frederic Beigbeder",
                exemplaires = 1
            };

            var frivoliteSerieuse = new Ouvrages()
            {
                titre = "La frivolite est une affaire serieuse",
                auteur = "Frederic Beigbeder",
                exemplaires = 1
            };

            var petitChose = new Ouvrages()
            {
                titre = "Le petit Chose",
                auteur = "Alphonse Daudet",
                exemplaires = 1
            };

            var lettresMoulin = new Ouvrages()
            {
                titre = "Les lettres de mon moulin",
                auteur = "Alphonse Daudet",
                exemplaires = 2
            };

            var tartarinAlpes = new Ouvrages()
            {
                titre = "Tartarin sur les Alpes",
                auteur = "Alphonse Daudet",
                exemplaires = 2
            };

            var tartarinTarascon = new Ouvrages()
            {
                titre = "Tartarin de Tarascon",
                auteur = "Alphonse Daudet",
                exemplaires = 1
            };

            await bibliotheque.Utilisateurs.AddRangeAsync(new Utilisateurs[] { henry, anais, felix, toussaint, kinza, jian });
            await bibliotheque.Ouvrages.AddRangeAsync(new Ouvrages[] {stupeurTremblements,formVie,barbeBleue,journalHirondelle,acideSulfurique,mystereExcellence,
                                                                        sabotageAmoureux,voyageHiver,lesCatilinaires,metaphysique,premierApocalypse,secoursPardon,
                                                                        romanFrancais,memoiresDeranges,francs,hommePleure,vacancesComa,frivoliteSerieuse,petitChose,
                                                                        lettresMoulin,tartarinAlpes,tartarinTarascon});

            //voir comment ajouter les resrvations
        }
    }
}
