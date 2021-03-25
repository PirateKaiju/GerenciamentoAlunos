using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        String encriptPassword(String password); //TODO: ISOLATE IN AN INFRA FUNCTION
    }
}
