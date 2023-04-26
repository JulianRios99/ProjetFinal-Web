using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Donnees;
using ProjetFinal.Models;
using System.Security.Claims;

// AuthentificationController sera responsable de la connexion et déconnexion des utilisateurs

namespace ProjetFinal.Controllers
{
    public class AuthentificationController : Controller
    {

        private readonly Bibliotheque _bibliotheque;


        public AuthentificationController(Bibliotheque bibliotheque)
        {
            _bibliotheque = bibliotheque;
        }

        // Methode responsable de l’affichage du formulaire de connexion
        public IActionResult Connexion()
        {

            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]

        // Type complexe = type compose comme une classe (utilisateur est un type complexe =compose)
        // Type simple  = string, int..... (UrL et un type simple = string)
        public async Task<IActionResult> Connexion(Connexion formulaire, string? ReturnUrl)
        {
            if (!ModelState.IsValid) { return View(); }

            var user = await _bibliotheque.Utilisateurs.FromSql($@"
                SELECT * FROM [Utilisateurs]
                WHERE [Courriel] = {formulaire.Courriel}
                AND [MotDePasse] = HASHBYTES('SHA2_256',{formulaire.MotDePasse})
            ")
                .Include(v => v.Roles)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "informations invalides");
                return View();
            }

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString())
            };

            user.Roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Nom));
            });


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,  // Ici on dit quon va utiliser un cookie
                new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)), //On  passe les informations
                new AuthenticationProperties { });

            //Response.Cookies.Append("Name", user.Nom + " " + user.Prenom);

            //Avec LocalRedirect on s'assure que si qqun allait modifier les info envoyés pour le formalaire dun URL vers un site externe LocalRedirect le blocarait   
            // Car localredirect verifie que l'url passé en parametre est un URL local
            return ReturnUrl != null ? LocalRedirect(ReturnUrl) : RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Authorize]
        public async Task<IActionResult> Déconnexion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Interdit()
        {
            return View();
        }
        

        


    }
}
