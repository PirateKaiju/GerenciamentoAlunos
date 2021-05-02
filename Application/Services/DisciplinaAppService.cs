using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class DisciplinaAppService : IDisciplinaAppService
    {

        private IDisciplinaRepository _repository = null;

        public DisciplinaAppService(IDisciplinaRepository repository)
        {
            this._repository = repository;
        }
        public bool Create(Disciplina entidade)
        {
            this._repository.Create(entidade);
            return true;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Disciplina Read(string id)
        {
            return this._repository.Read(id);
        }

        public Disciplina ReadByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
