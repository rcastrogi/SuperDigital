using SuperDigital.Domain.Entity;
using SuperDigital.Domain.Validation;
using System.Collections.Generic;

namespace SuperDigital.Domain.Service
{
    public class ApplicationService
    {
        public List<string> IsValid(TransferEntity transfer)
        {
            return TransferValidation.ValidationRules(transfer);
        }
    }
}
