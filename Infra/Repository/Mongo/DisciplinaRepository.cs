using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Mongo
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        public void Create(Disciplina entidade)
        {
            Db.insertDocument<Disciplina>("disciplina", entidade);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Disciplina Read(string id)
        {
           return Db.retrieveDocumentById<Disciplina>("disciplina", id);
        }

        public List<Disciplina> ReadAll(string id)
        {
            throw new NotImplementedException();
        }
    }
}
