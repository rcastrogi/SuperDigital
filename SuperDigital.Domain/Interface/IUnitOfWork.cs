using System;

namespace SuperDigital.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
