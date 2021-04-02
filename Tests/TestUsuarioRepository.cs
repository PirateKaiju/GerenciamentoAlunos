using Domain.Models;
using Infra.Repository.Mongo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{

    [TestClass]
    class TestUsuarioRepository
    {
        [TestMethod]
        public void TestUsuarioCreate()
        {

            /*DisciplinaRepository disRepo = new DisciplinaRepository();

            disRepo.Create();*/

            UsuarioRepository usrRepo = new UsuarioRepository();

            Usuario usuario = new Usuario();
            usuario.username = "somename";
            usuario.password = "1234";
            usuario.role = "Aluno";


            usrRepo.Create(usuario);

        }
    }
}
