using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Web.Services.Authentication;

namespace UI.Web.Controllers
{
    public class UsuarioController : Controller
    {

        private IUsuarioAppService _usuarioAppService = null;
        private IHttpContextAccessor _httpContextAccessor = null;

        public UsuarioController(IUsuarioAppService usuarioAppService, IHttpContextAccessor httpContextAccessor) 
        {
            this._usuarioAppService = usuarioAppService;
            this._httpContextAccessor = httpContextAccessor; 
        }

        // GET: Usuario
        public ActionResult Index()
        {
            //TEST ONLY
            Console.WriteLine("CURRENT USER: ");
            Console.WriteLine(_httpContextAccessor.HttpContext.User.Claims.Count());
            Console.WriteLine(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value);

            return View();
        }

        // GET: Usuario/Details/5
        [Authorize(Roles = "Aluno")] //TODO: CREATE ROLE ON DOMAIN? DONT THINK ITS NECESSARY... MAYBE AS AN ENUM
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Usuario loginUsuario) { //TODO: USE A VIEWMODEL INSTEAD?

            //Verificacao de dados (a partir da infra?)
            Usuario usuario = this._usuarioAppService.ReadByName(loginUsuario.username);

            if (usuario != null) {

                bool loginValid = this._usuarioAppService.VerifyPassword(loginUsuario.password, usuario.password);

                

                if (loginValid) { //IS IT NECESSARY TO SEPARATE THIS BLOCK IN SOME FORM OF ENCAPSULATION?

                    List<Claim> userClaims = CookieClaimAuthentication.makeUserClaims(usuario);

                    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    await HttpContext.SignInAsync(new ClaimsPrincipal(userIdentity));

                    return RedirectToAction("Index", "Home");

                }

            }

            return View(loginUsuario);

            

        }

        // GET: Usuario/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Usuario usuarioRegistrando) 
        {

            //TODO: HANDLE DIFFERENT USER TYPES
            // MAYBE USE MULTIPLE VIEWMODELS or handle registration on each 'user type' controller?

            //TODO: ADD PASSWORD CONFIRMATION
            try
            {
                // TODO: Add insert logic here

                if (this._usuarioAppService.ReadByName(usuarioRegistrando.username) == null) {

                    //TODO: VALIDATE PASSWORD AND STUFF, PROBABLY WILL USE SOME ORGANIZED VALIDATOR

                    usuarioRegistrando.role = "Aluno"; //TODO: TEMPORARY, REMOVE THIS

                    this._usuarioAppService.Create(usuarioRegistrando);

                    return RedirectToAction(nameof(Index));

                }

                return View(usuarioRegistrando);
                
            }
            catch
            {
                return View(usuarioRegistrando);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}