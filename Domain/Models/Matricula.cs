using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Matricula
    {
        public String Id { get; set; }
        public String AlunoId { get; set; }
        public String DisciplinaId { get; set; }
        public String Descricao { get; set; }

        //TODO: ADICIONAR DATA MATRICULA
    }
}
