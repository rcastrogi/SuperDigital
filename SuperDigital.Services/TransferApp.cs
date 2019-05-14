using Superdigital.Repository.DataModel;
using SuperDigital.Domain.Entity;
using SuperDigital.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Services
{
    public class TransferApp : ApplicationService
    {
        public List<string> errors = new List<string>();

        public TransferApp(TransferEntity transfer)
        {
            errors = IsValid(transfer);

            if(errors.Count == 0)
            {
                TransferRepository _dados = new TransferRepository();

                var retorno = _dados.RealizaTransferencia(transfer);

                if (!retorno) errors.Add("Ocorreu um erro ao gravar as informações");
            }
        }
    }
}
