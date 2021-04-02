using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {

        private IUsuarioRepository _repository = null;

        public UsuarioAppService(IUsuarioRepository repository) {

            this._repository = repository;

        }
        public bool Create(Usuario entidade)
        {
            this._repository.Create(entidade);

            return true;
        }

        public bool Delete(string id)
        {
            this._repository.Delete(id);

            return true;
        }

        public Usuario Read(string id)
        {
            return this._repository.Read(id);
        }

        public Usuario ReadByName(string name)
        {
            return this._repository.ReadByName(name);
        }
    }
}
