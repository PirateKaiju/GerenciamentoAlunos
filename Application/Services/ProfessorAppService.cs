using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Domain.Models;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProfessorAppService : IProfessorAppService
    {

        private IProfessorRepository _repository = null;

        public ProfessorAppService(IProfessorRepository repository)
        {
            this._repository = repository;
        }

        public bool Create(Professor entidade)
        {
            this._repository.Create(entidade);

            return true;
        }

        //TODO: FINISH IMPLEMENTATIONS
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Professor Read(string id)
        {
            return this._repository.Read(id);
        }

        public Professor ReadByName(string name)
        {
            //return this._repository.ReadByName(name);
            throw new NotImplementedException();
        }
    }
}
