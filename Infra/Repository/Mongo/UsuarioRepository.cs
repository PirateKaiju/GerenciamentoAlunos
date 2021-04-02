using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Mongo
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Create(Usuario entidade)
        {
            //entidade.password = this.encriptPassword(entidade.password);
            Db.insertDocument<Usuario>("usuario", entidade);
        }

        public void Delete(string id)
        {
            Db.deleteDocument<Usuario>("usuario", id);
        }

        //TODO: SEPARATE THIS IN A SPECIFIC INFRA MODULE?
        /*public string encriptPassword(string password)
        {
            throw new NotImplementedException();
        }

        public string decriptPassword() {

            throw new NotImplementedException();

        }*/

        public Usuario ReadByName(string name) {

            return Db.retrieveDocumentByAttribute<Usuario>("usuario", "username", name);

        }

        public Usuario Read(string id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ReadAll(string id)
        {
            throw new NotImplementedException();
        }
    }
}
