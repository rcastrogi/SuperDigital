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
            if(lancto.ContaCorrenteOriId <= 0) errors.Add(ReturnMessage.ContaOrigem_Obrigatorio);
            if (lancto.ContaCorrenteDesId <= 0) errors.Add(ReturnMessage.ContaDestino_Obrigatorio);
            if (lancto.Valor <= 0) errors.Add(ReturnMessage.Valor_Obrigatorio);

            return errors;
        }

        public static List<string> ValidationRules(TransferEntity transfer)
        {
            List<string> errors = new List<string>();
            if (transfer.BancoOri <= 0) errors.Add(ReturnMessage.BancoOrigem_Obrigatorio);
            if (transfer.AgenciaOri <= 0) errors.Add(ReturnMessage.ContaOrigem_Obrigatorio);
            if (transfer.ContaOri <= 0) errors.Add(ReturnMessage.AgenciaOrigem_Obrigatorio);
            if (transfer.DigitoOri <= 0) errors.Add(ReturnMessage.DigitoOrigem_Obrigatorio);

            if (transfer.BancoDes <= 0) errors.Add(ReturnMessage.BancoDestino_Obrigatorio);
            if (transfer.AgenciaDes <= 0) errors.Add(ReturnMessage.ContaDestino_Obrigatorio);
            if (transfer.ContaDes <= 0) errors.Add(ReturnMessage.AgenciaDestino_Obrigatorio);
            if (transfer.DigitoDes <= 0) errors.Add(ReturnMessage.DigitoDestino_Obrigatorio);

            if (transfer.Valor <= 0) errors.Add(ReturnMessage.Valor_Obrigatorio);

            return errors;
        }
    }
}
