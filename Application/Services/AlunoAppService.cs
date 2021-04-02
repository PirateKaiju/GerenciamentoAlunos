using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private IAlunoRepository _repository = null;
        public AlunoAppService(IAlunoRepository repository) {
            this._repository = repository;
        }
        public bool Create(Aluno aluno) //TODO: USE A VIEWMODEL / DTO?
        {
            this._repository.Create(aluno);

            return true;
        }

        public bool Delete(string id)
        {
            this._repository.Delete(id);

            return true;
        }

        public Aluno Read(string id)
        {
            return this._repository.Read(id);
        }

        public Aluno ReadByName(string name) 
        {
            throw new NotImplementedException();
        }
    }
}
