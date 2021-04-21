using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Web.Models
{
    public class RegisterAlunoViewModel //Allow us to register both the user and student. Might change later
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
