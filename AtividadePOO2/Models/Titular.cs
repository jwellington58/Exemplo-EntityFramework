using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadePOO.Models
{
    public class Titular
    {
        public Titular()
        {
            Contas = new HashSet<ContaTitular>();
            
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public ICollection<ContaTitular> Contas { get; set; }
    }
}
