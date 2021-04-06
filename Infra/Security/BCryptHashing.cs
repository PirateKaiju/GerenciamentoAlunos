using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Security
{
    public class BCryptHashing : IHashing
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string inputPassword, string hashedRealPassword)
        {
            //TODO: ADD TRY CATCH CLAUSES
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedRealPassword);
        }
    }
}
