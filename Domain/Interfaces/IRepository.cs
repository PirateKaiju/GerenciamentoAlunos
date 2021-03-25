using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public  interface IRepository<T> where T: class
    {
        void Create(T entidade);
        T Read(String id);
        List<T> ReadAll(String id);
        void Delete(String id); //Should be boolean?

    }
}
