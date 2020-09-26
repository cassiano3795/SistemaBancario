using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBancario.Domain.Interfaces.Services;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Services
{
    public class BaseService<T> : IService<T> where T : BaseModel
    {
        // private readonly BaseRepository<T> _ba
        private bool disposedValue;

        public Task<T> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<IList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<T> Create(T model)
        {
            throw new NotImplementedException();
        }
        public Task<T> Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<T> Update(T model)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BaseService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
