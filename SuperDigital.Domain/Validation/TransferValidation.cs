using SuperDigital.Domain.Entity;
using SuperDigital.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Validation
{
    public static class TransferValidation
    {
        public static List<string> ValidationRules(LancamentoEntity lancto)
        {
            List<string> errors = new List<string>();
            if(lancto.FromContaCorrenteId <= 0) errors.Add(ReturnMessage.ContaOrigem_Obrigatorio);
            if (lancto.ToContaCorrenteId <= 0) errors.Add(ReturnMessage.ContaDestino_Obrigatorio);
            if (lancto.Valor <= 0) errors.Add(ReturnMessage.Valor_Obrigatorio);

            return errors;
        }
    }
}
