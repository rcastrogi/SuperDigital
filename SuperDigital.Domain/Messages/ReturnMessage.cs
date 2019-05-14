using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Messages
{
    public static partial class ReturnMessage
    {
        public const string BancoOrigem_Obrigatorio = "Banco origem obrigatório.";
        public const string ContaOrigem_Obrigatorio = "Conta origem obrigatória.";
        public const string AgenciaOrigem_Obrigatorio = "Agência origem obrigatória.";
        public const string DigitoOrigem_Obrigatorio = "Digito origem obrigatório.";

        public const string BancoDestino_Obrigatorio = "Banco destino obrigatório.";
        public const string ContaDestino_Obrigatorio = "Conta destino obrigatória.";
        public const string AgenciaDestino_Obrigatorio = "Agência destino obrigatória.";
        public const string DigitoDestino_Obrigatorio = "Digito destino obrigatório.";

        public const string Valor_Obrigatorio = "Valor Obrigatório.";
    }
}
