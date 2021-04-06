using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IHashing
    {
        string Hash(string password);

        bool Verify(string inputPassword, string hashedRealPassword);
    }
}
