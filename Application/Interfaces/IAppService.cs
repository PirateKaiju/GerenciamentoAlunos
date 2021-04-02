using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IAppService<T> where T: class
    {
        bool Create(T entidade);
        T Read(string id);
        T ReadByName(string name);
        bool Delete(string id);
    }
}
