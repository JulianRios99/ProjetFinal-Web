using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Donnees;
using ProjetFinal.Models;

namespace ProjetFinal.Controllers
{
    public class ReservationController : Controller
    {

        private readonly Bibliotheque _bibliotheque;

        public ReservationController(Bibliotheque bibliotheque)
        {
            _bibliotheque = bibliotheque;
        }
        // Liste de toutes les ouvrages
        public async Task<IActionResult> Index()
        {
            var reservations = await _bibliotheque.Reservations.Include(v => v.Utilisateurs).Include(v => v.Ouvrage)
                .ToListAsync();

            return View(reservations);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Suppression(int id)
        {
            var reserv = await _bibliotheque.Reservations.FindAsync(id);
                
            if (reserv != null)
            {
                _bibliotheque.Reservations.Remove(reserv);
                await _bibliotheque.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var reserv = await _bibliotheque.Reservations.FindAsync(id);

            if (reserv != null)
            {
                return View(reserv);
            }

            return NotFound();
        }

        // [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modification(int id, Reservations formulaire)
        {
            if (!ModelState.IsValid)
            {
                return View(formulaire);
            }

            var ouvrage = await _bibliotheque.Reservations.FindAsync(id);

            if (ouvrage != null)
            {
                ouvrage.ID = formulaire.ID;
                ouvrage.Utilisateurs.ID = formulaire.Utilisateurs.ID;
                ouvrage.Ouvrage.ID = formulaire.Ouvrage.ID;

                await _bibliotheque.SaveChangesAsync();

                return RedirectToAction(nameof(ReservationController.Index));
            }

            return NotFound();
        }

        public async Task<IActionResult> Modification(int id)
        {
            var reserv = await _bibliotheque.Reservations.FindAsync(id);

            if (reserv != null)
            {
                return View(reserv);
            }

            return NotFound();
        }


    }
}
