using Domain.Models;
using Infra.Repository.Mongo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{

    [TestClass]
    class TestDisciplinaRepository
    {
        [TestMethod]
        public void TestMethod1 (){

            DisciplinaRepository disRepo = new DisciplinaRepository();

            Disciplina disciplina = new Disciplina();

            disciplina.nome = "Teste disciplina 1";
            disciplina.descricao = "Teste descricao 1";
            
            disRepo.Create(disciplina);

        }
    }
}
