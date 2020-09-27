using System;

namespace SistemaBancario.Domain.Observers
{
    public abstract class AbastractObserver<T> : IObserver<T>
    {
        private bool _disposed;
        protected IDisposable Cancellation;

        public AbastractObserver()
        {
            _disposed = false;
        }

        public bool IsDisposed => _disposed;
        public abstract void OnCompleted();

        public abstract void OnError(Exception error);

        public abstract void OnNext(T value);
    }
}
