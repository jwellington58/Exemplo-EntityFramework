using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadePOO.Models
{
    public class ContaTitular
    {
        
        public int TitularId { get; set; }
        public int ContaId { get; set; }
        public virtual Conta Conta { get; set; }
        public virtual Titular Titular { get; set; }
    }
}
