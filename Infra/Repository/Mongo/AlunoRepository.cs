using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Domain.Models;
using MongoDB.Bson;

namespace Infra.Repository.Mongo
{
    public class AlunoRepository : IAlunoRepository
    {
        public void Create(Aluno entidade)
        {
            ////entidade.Id = ObjectId.GenerateNewId().ToString();
            Db.insertDocument<Aluno>("aluno", entidade);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Aluno Read(string id)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ReadAll(string id)
        {
            throw new NotImplementedException();
        }
    }
}
