using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Entity
{
    public class ContaCorrenteEntity
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Banco { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public int Digito { get; set; }
        public decimal Saldo { get; set; }
    }
}
