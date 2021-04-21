using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using UI.Web.Models;
using Domain.Models;

namespace UI.Web.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor

        private IProfessorAppService _professorAppService = null;
        private IUsuarioAppService _usuarioAppService = null;
        private IHttpContextAccessor _httpContextAccessor = null;
        

        public ProfessorController(IProfessorAppService professorAppService, IUsuarioAppService usuarioAppService, IHttpContextAccessor httpContextAccessor)
        {

            this._professorAppService = professorAppService;
            this._usuarioAppService = usuarioAppService;
            this._httpContextAccessor = httpContextAccessor;
            

        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Professor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterProfessorViewModel professorUsuario)
        {
            try
            {
                // TODO: Add insert logic here

                if (this._usuarioAppService.ReadByName(professorUsuario.Username) == null) //Use this simple validation for any other constraint
                {

                    //TODO: VALIDATE PASSWORD AND STUFF, PROBABLY WILL USE SOME ORGANIZED VALIDATOR

                    //TODO: FIND OUT IF THERES A BETTER WAY TO POPULATE AN OBJECT
                    Usuario usuarioRegistrando = new Usuario
                    {
                        username = professorUsuario.Username,
                        password = professorUsuario.Password,
                        role = "Professor"
                    };


                    this._usuarioAppService.Create(usuarioRegistrando);


                    Professor professorRegistrando = new Professor
                    {

                        nome = professorUsuario.Nome,

                        UsuarioId = this._usuarioAppService.ReadByName(professorUsuario.Username).Id //The user must be created first

                    };


                    this._professorAppService.Create(professorRegistrando);

                    return RedirectToAction(nameof(Index));

                }

                return View(professorUsuario);

            }
            catch
            {
                return View(professorUsuario);
            }
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Professor/Edit/5
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

        // GET: Professor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Professor/Delete/5
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