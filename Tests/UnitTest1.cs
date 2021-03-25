using Domain.Models;
using Infra.Repository.Mongo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AlunoRepository alnRepo = new AlunoRepository();

            Aluno a1 = new Aluno();

            a1.nome = "Teste aluno 1";
            a1.endereco = "Rua x numero y";

            alnRepo.Create(a1);

        }
    }
}
