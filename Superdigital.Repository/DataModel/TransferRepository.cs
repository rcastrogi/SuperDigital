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

        public bool RealizaLancamento(LancamentoEntity lancto)
        {
            const string proc = "sp_Lancamento_Transfer";

            var paramContaOrigem = DataHelperParameters.CreateParameter("@FromContaCorrenteId", lancto.FromContaCorrenteId);
            var paramContaDestino = DataHelperParameters.CreateParameter("@ToContaCorrenteId", lancto.ToContaCorrenteId);
            var paramContaOrigemSaldoAtual = DataHelperParameters.CreateParameter("@Valor", lancto.Valor);

            return _unitOfWork.Get<bool>(proc, paramContaOrigem, paramContaDestino);
        }
    }
}
