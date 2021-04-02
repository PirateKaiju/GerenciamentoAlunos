using Domain.Models;
using Infra.Repository.Mongo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{

    [TestClass]
    class TestProfessorRepository
    {
        [TestMethod]
        public void TestMethod1() {

            /*DisciplinaRepository disRepo = new DisciplinaRepository();

            disRepo.Create();*/

            ProfessorRepository profRepo = new ProfessorRepository();

            Professor professor = new Professor();
            professor.nome = "Teste Professor 1";
            

            profRepo.Create(professor);

        }
    }
}
