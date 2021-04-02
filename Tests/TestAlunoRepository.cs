using Domain.Models;
using Infra.Repository.Mongo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class TestAlunoRepository
    {
        [TestMethod]
        public void TestMethod1()
        {
            AlunoRepository alnRepo = new AlunoRepository();

            Aluno a1 = new Aluno();

            a1.nome = "Teste aluno 1";
            a1.endereco = "Rua x numero y";

            alnRepo.Create(a1);
            //Console.WriteLine(a1.Id);

        }

        [TestMethod]
        public void TestMethod2()
        {
            AlunoRepository alnRepo = new AlunoRepository();

            Aluno a1 = new Aluno();

            a1.nome = "Teste aluno read";
            a1.endereco = "Rua xx numero y";

            alnRepo.Create(a1);

            Aluno encontrado = alnRepo.Read(a1.Id);

            Console.WriteLine(encontrado.nome + " : " + encontrado.endereco);

            alnRepo.Delete(a1.Id);
            

        }

        
    }
}
