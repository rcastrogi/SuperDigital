using SuperDigital.Domain.Entity;
using SuperDigital.Domain.Validation;
using System.Collections.Generic;

namespace SuperDigital.Domain.Service
{
    public class ApplicationService
    {
        public List<string> IsValid(LancamentoEntity lancto)
        {
            var Validation = TransferValidation.ValidationRules(lancto);

            if(Validation.Count == 0)
            {
                return null;
            }
            else
            {
                return Validation;
            }
        }
    }
}
