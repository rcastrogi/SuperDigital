using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Entity
{
    public class TransferEntity
    {
        public int BancoOri { get; set; }
        public int AgenciaOri { get; set; }
        public int ContaOri { get; set; }
        public int DigitoOri { get; set; }

        public int BancoDes { get; set; }
        public int AgenciaDes { get; set; }
        public int ContaDes { get; set; }
        public int DigitoDes { get; set; }

        public decimal Valor { get; set; }
    }
}
