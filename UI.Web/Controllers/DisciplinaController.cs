using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers
{
    public class DisciplinaController : Controller
    {

        private IDisciplinaAppService _disciplinaAppService = null;
        private IHttpContextAccessor _httpContextAccessor = null;
        private IProfessorAppService _professorAppService = null;
        private IUsuarioAppService _usuarioAppService = null;

        public DisciplinaController(IDisciplinaAppService _disciplinaAppService, IUsuarioAppService usuarioAppService, IProfessorAppService professorAppService, IHttpContextAccessor httpContextAccessor)
        {
            this._disciplinaAppService = _disciplinaAppService;
            this._httpContextAccessor = httpContextAccessor;
            this._professorAppService = professorAppService;
            this._usuarioAppService = usuarioAppService;
        }

        // GET: Disciplina
        public ActionResult Index()
        {
            return View();
        }

        // GET: Disciplina/Details/5
        public ActionResult Details(String id)
        {

            Disciplina disciplina = this._disciplinaAppService.Read(id);

            return View(disciplina);
        }

        [Authorize(Roles = "Professor")]
        // GET: Disciplina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Professor")]
        public ActionResult Create(Disciplina disciplina)
        {
            try
            {
                // TODO: Add insert logic here
                // TODO: ADD VALIDATION LOGIC

                Usuario currentUsr = this._usuarioAppService.ReadByName(this._httpContextAccessor.HttpContext.User.FindFirst("UserName").Value);
                //this._httpContextAccessor.HttpContext.User.FindFirst("UserName").Value;

                

                disciplina.ProfessorId = this._professorAppService.ReadByAssociatedUser(currentUsr.Id).Id;

                this._disciplinaAppService.Create(disciplina);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Disciplina/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Disciplina/Edit/5
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

        // GET: Disciplina/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Disciplina/Delete/5
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