using SuperDigital.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Entity
{
    public class LancamentoEntity
    {
        public int Id { get; set; }
        public int ContaCorrenteOriId { get; set; }
        public int ContaCorrenteDesId { get; set; }
        public bool Debito { get; set; }
        public decimal Valor { get; set; }
        public DateTime DtLancamento { get; set; }
    }
}
