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

        public UsuarioController(IUsuarioAppService usuarioAppService) 
        {
            this._usuarioAppService = usuarioAppService;
        }

        // GET: Usuario
        public ActionResult Index()
        {
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
        public async Task<ActionResult> Login(IFormCollection collection) {

            



            //Verificacao de dados (a partir da infra?)
            Usuario usuario = this._usuarioAppService.ReadByName("somename");

            List<Claim> userClaims = CookieClaimAuthentication.makeUserClaims(usuario);

            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

            await HttpContext.SignInAsync(new ClaimsPrincipal(userIdentity));

            return RedirectToAction("Index", "Home");

        }

        // GET: Usuario/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
        {

            //TODO: HANDLE DIFFERENT USER TYPES
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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