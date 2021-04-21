using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class AlunoController : Controller
    {
        IAlunoAppService _alunoApp = null;
        IUsuarioAppService _usuarioApp = null;
        public AlunoController(IAlunoAppService alunoApp, IUsuarioAppService usuarioApp) {

            this._alunoApp = alunoApp;
            this._usuarioApp = usuarioApp;

        }
        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        // GET: Aluno/Details/5
        public ActionResult Details(string id)
        {
            Aluno aluno = this._alunoApp.Read(id);

            return View(aluno);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterAlunoViewModel alunouser)
        {
            try
            {

                if (this._usuarioApp.ReadByName(alunouser.Username) == null) //Use this simple validation for any other constraint
                {

                    //TODO: VALIDATE PASSWORD AND STUFF, PROBABLY WILL USE SOME ORGANIZED VALIDATOR

                    //TODO: FIND OUT IF THERES A BETTER WAY TO POPULATE AN OBJECT
                    Usuario usuarioRegistrando = new Usuario { 
                        username = alunouser.Username,
                        password = alunouser.Password,
                        role = "Aluno"
                    };


                    this._usuarioApp.Create(usuarioRegistrando);


                    Aluno alunoRegistrando = new Aluno
                    {

                        nome = alunouser.Nome,
                        endereco = alunouser.Endereco,
                        UsuarioID = this._usuarioApp.ReadByName(alunouser.Username).Id //The user must be created first

                    };


                    this._alunoApp.Create(alunoRegistrando);

                    return RedirectToAction(nameof(Index));

                }

                return View(alunouser);

            }
            catch
            {
                return View(alunouser);
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aluno/Edit/5
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

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aluno/Delete/5
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