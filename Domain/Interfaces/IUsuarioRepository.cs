using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Usuario ReadByName(string name); //TODO: REFACTOR LATER
        /*String encriptPassword(String password); //TODO: ISOLATE IN AN INFRA FUNCTION
        String decriptPassword(String password); //TODO: MIGHT NOT BE NEEDED*/



    }
}
