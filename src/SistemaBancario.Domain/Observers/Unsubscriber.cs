using System;
using System.Collections.Generic;

namespace SistemaBancario.Domain.Observers
{
    public class Unsubscriber<T> : IDisposable
    {
        private readonly IList<IObserver<T>> _observers;
        private readonly IObserver<T> _observer;

        public Unsubscriber(IList<IObserver<T>> observers, IObserver<T> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (!_observers.Contains(_observer))
                return;

            _observers.Remove(_observer);
        }
    }
}
