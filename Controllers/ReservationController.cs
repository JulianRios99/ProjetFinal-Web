using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Donnees;
using ProjetFinal.Models;
using System.Net;
using System.Security.Claims;

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

        public async Task<IActionResult> Confirmation(int id)
        {
            var reserv = await _bibliotheque.Reservations.FindAsync(id);
            if (reserv != null)
            {
                return View(reserv);
            }

            return NotFound();
        }

       
        public async Task<IActionResult> Suppression(int id)
        {
            var reserv = await _bibliotheque.Reservations
                .Include(v => v.Ouvrage)
                .Include(v => v.Utilisateurs)
                .Where(v => v.ID == id)
                .FirstAsync();

            if (reserv != null)
            {

                var ouvrage = await _bibliotheque.Ouvrages.FindAsync(reserv.Ouvrage.ID);
                var utilisateur = await _bibliotheque.Utilisateurs.FindAsync(reserv.Utilisateurs.ID);

                _bibliotheque.Reservations.Remove(reserv);

                ouvrage.Exemplaires += 1;
                utilisateur.Reservations.Remove(reserv);

                await _bibliotheque.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }



        // [Authorize(Roles = "Admin,User")]
        [HttpGet("[action]/{id:int}/{userId:int}")]

        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Reserver(int id, int userId)

        {
            var ouvrage = await _bibliotheque.Ouvrages.FindAsync(id);

            var utilisateur = await _bibliotheque.Utilisateurs.FindAsync(userId);

            var nombreReserations = await _bibliotheque.Reservations
                .Where(v => v.Utilisateurs.Equals(utilisateur))
                .CountAsync();

            if (ouvrage != null && utilisateur != null)
            {
                if (nombreReserations < 3 && ouvrage.Exemplaires > 0)
                {
                    await _bibliotheque.Reservations.AddAsync(new Reservations { Utilisateurs = utilisateur, Ouvrage = ouvrage });

                    ouvrage.Exemplaires -= 1;

                    await _bibliotheque.SaveChangesAsync();

                    return View(ouvrage);
                }
            }

            return NotFound();
        }
       

    }
}
