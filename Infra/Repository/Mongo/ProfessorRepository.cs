using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Mongo
{
    public class ProfessorRepository : IProfessorRepository
    {
        public void Create(Professor entidade)
        {
            Db.insertDocument<Professor>("professor", entidade);
        }

        public void Delete(string id)
        {
            Db.deleteDocument<Professor>("professor", id);
        }

        public Professor Read(string id)
        {
            return Db.retrieveDocumentById<Professor>("professor", id);
        }

        public List<Professor> ReadAll(string id)
        {
            throw new NotImplementedException();
        }

        public Usuario retrieveAssociatedUser(string usuarioId)
        {
            return Db.retrieveDocumentById<Usuario>("usuario", usuarioId);
        }

        public Professor retrieveProfessorByAssociatedUser(string usuarioId) {

            return Db.retrieveDocumentByAttribute<Professor>("professor", "UsuarioId", usuarioId);

        }
    }
}
