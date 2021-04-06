using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUsuarioAppService: IAppService<Usuario>
    {
        bool VerifyPassword(string inputPassword, string hashedRealPassword);
    }
}
