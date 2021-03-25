using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Disciplina
    {
        public String Id { get; set; }
        public String nome { get; set; }
        public String descricao { get; set; }
        public String ProfessorId { get; set; }
    }
}
