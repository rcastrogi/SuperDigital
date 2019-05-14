using Superdigital.Repository.Dapper;
using SuperDigital.Domain.Entity;
using SuperDigital.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superdigital.Repository.DataModel
{
    public class TransferRepository
    {

        private readonly DapperUnitOfWork _unitOfWork;

        public TransferRepository()
        {
            IUnitOfWork unitOfWork = new DapperUnitOfWork();
            _unitOfWork = (DapperUnitOfWork)unitOfWork;
        }

        public bool RealizaTransferencia(TransferEntity transfer)
        {
            const string proc = "sp_Lancamento_Transfer";

            var transferContas = VerificaContas(transfer);

            if (transferContas != null)
            {
                LancamentoEntity lancto = new LancamentoEntity()
                {
                    ContaCorrenteOriId = transferContas.ContaCorrenteOriId,
                    ContaCorrenteDesId = transferContas.ContaCorrenteDesId,
                    Valor = transfer.Valor
                };

                var paramContaOrigem = DataHelperParameters.CreateParameter("@FromContaCorrenteId", lancto.ContaCorrenteOriId);
                var paramContaDestino = DataHelperParameters.CreateParameter("@ToContaCorrenteId", lancto.ContaCorrenteDesId);
                var paramContaOrigemSaldoAtual = DataHelperParameters.CreateParameter("@Valor", lancto.Valor);

                return _unitOfWork.Get<bool>(proc, paramContaOrigem, paramContaDestino);
            }
            else
            {
                return false;
            }
        }

        private TransferContasEntity VerificaContas(TransferEntity transfer)
        {
            const string proc = "sp_ContaCorrente_Transfer";

            var paramBancoOri = DataHelperParameters.CreateParameter("@BancoOri", transfer.BancoOri);
            var paramAgenciaOri = DataHelperParameters.CreateParameter("@AgenciaOri", transfer.AgenciaOri);
            var paramContaOri = DataHelperParameters.CreateParameter("@ContaOri", transfer.ContaOri);
            var paramDigitoOri = DataHelperParameters.CreateParameter("@DigitoOri", transfer.DigitoOri);
            var paramBancoDes = DataHelperParameters.CreateParameter("@BancoDes", transfer.BancoDes);
            var paramAgenciaDes = DataHelperParameters.CreateParameter("@AgenciaDes", transfer.AgenciaDes);
            var paramContaDes = DataHelperParameters.CreateParameter("@ContaDes", transfer.ContaDes);
            var paramDigitoDes = DataHelperParameters.CreateParameter("@DigitoDes", transfer.DigitoDes);

            return _unitOfWork.Get<TransferContasEntity>(proc, paramBancoOri, paramAgenciaOri, paramContaOri, paramDigitoOri, paramBancoDes, paramAgenciaDes, paramContaDes, paramDigitoDes);
        }
    }
}
