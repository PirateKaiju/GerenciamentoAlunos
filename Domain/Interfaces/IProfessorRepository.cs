using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProfessorRepository: IRepository<Professor>
    {
        Usuario retrieveAssociatedUser(string usuarioId); //REMOVE LATER

        Professor retrieveProfessorByAssociatedUser(string usuarioId);
    }
}
