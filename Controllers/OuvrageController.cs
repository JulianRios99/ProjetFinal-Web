using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Donnees;
using ProjetFinal.Models;

namespace ProjetFinal.Controllers
{
    public class OuvrageController : Controller
    {
        private readonly Bibliotheque _bibliotheque;

        public OuvrageController(Bibliotheque bibliotheque)
        {
            _bibliotheque = bibliotheque;
        }



        public async Task<IActionResult> Index()
        {
            var ouvrage = await _bibliotheque.Ouvrages.ToListAsync();
            return View(ouvrage);
        }


        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Modification(int id)
        {
            var ouvrage = await _bibliotheque.Ouvrages.FindAsync(id);

            if (ouvrage != null)
            {
                return View(ouvrage);
            }

            return NotFound();
        }


        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modification(int id, Ouvrages formulaire)
        {
            if (!ModelState.IsValid)
            {
                return View(formulaire);
            }

            var ouvrage = await _bibliotheque.Ouvrages.FindAsync(id);

            if (ouvrage != null)
            {
                ouvrage.Titre = formulaire.Titre;
                ouvrage.Auteur = formulaire.Auteur;
                ouvrage.Exemplaires = formulaire.Exemplaires;

                await _bibliotheque.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }


        public async Task<IActionResult> Ajouter(int id, int ouvrageId)
        {

            var utilisateur = await _bibliotheque.Utilisateurs.FindAsync(id);
            var ouvrage = await _bibliotheque.Ouvrages.FindAsync(ouvrageId);

            if (ouvrage == null || utilisateur == null)
            {
                return NotFound();
            }
            {

            }
            var nombreLimite = await _bibliotheque.Reservations.Include(v => v.Utilisateurs).Where(v => v.Utilisateurs.ID == id).ToListAsync();

            var nombre = nombreLimite.Count;

            if (nombre >= 3)
            {
                return RedirectToAction(nameof(Index));
            }

            var reserv = new Reservations { Ouvrage = ouvrage, Utilisateurs = utilisateur };

            await _bibliotheque.Reservations.AddAsync(reserv);
            await _bibliotheque.SaveChangesAsync();

            return View(nameof(Modification));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ajouter(Ouvrages donnes)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Modification), donnes);
            }

            await _bibliotheque.Ouvrages.AddAsync(new Ouvrages()
            {
                Titre = donnes.Titre,
                Auteur = donnes.Auteur,
                Exemplaires = donnes.Exemplaires
            });
            await _bibliotheque.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Confirmation(int id)
        {
            var ouvrage = await _bibliotheque.Ouvrages.FindAsync(id);

            if (ouvrage != null)
            {
                return View(ouvrage);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Suppression(int id)
        {
            var ouvrage = await _bibliotheque.Ouvrages.FindAsync(id);

            if (ouvrage != null)
            {
                _bibliotheque.Ouvrages.Remove(ouvrage);
                await _bibliotheque.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Recherche(string titre, string auteur)
        {
            //List<Ouvrages> found = new();
             List<Ouvrages> found = _bibliotheque.Ouvrages.ToList();

            if (!string.IsNullOrEmpty(titre))
               
            {
                found = _bibliotheque.Ouvrages.Where(x => x.Titre.ToLower().Contains(titre.ToLower())).ToList();
            
            }

            if (!string.IsNullOrEmpty(auteur))

            {
                found = _bibliotheque.Ouvrages.Where(x => x.Auteur.ToLower().Contains(auteur.ToLower())).ToList();
            }


            return View(found);

        }
    }
}
