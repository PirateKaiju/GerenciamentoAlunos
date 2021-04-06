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
        private IHashing _hasher = null;

        public UsuarioAppService(IUsuarioRepository repository, IHashing hasher) {

            this._repository = repository;
            this._hasher = hasher;

        }
        public bool Create(Usuario entidade)
        {
            entidade.password = this._hasher.Hash(entidade.password);
            
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

        public bool VerifyPassword(string inputPassword, string hashedRealPassword) {

            return this._hasher.Verify(inputPassword, hashedRealPassword);

        }
    }
}
