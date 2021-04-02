using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Usuario
    {
        public String Id { get; set; }
        public String username { get; set; }
        public String password { get; set; }

        //TODO: ADD EMAIL
        public String role { get; set; }

    }
}
