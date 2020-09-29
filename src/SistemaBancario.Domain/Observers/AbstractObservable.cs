using System;
using System.Collections.Generic;

namespace SistemaBancario.Domain.Observers
{
    public abstract class AbstractObservable<T> : IObservable<T>
    {
        protected readonly IList<IObserver<T>> Observers;
        protected IList<T> Items;

        public AbstractObservable()
        {
            Observers = new List<IObserver<T>>();
            Items = new List<T>();
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (Observers.Contains(observer))
                return new Unsubscriber<T>(Observers, observer);

            Observers.Add(observer);

            return new Unsubscriber<T>(Observers, observer);
        }

        public virtual void Add(T item)
        {
            if (Items.Contains(item))
                return;

            Items.Add(item);
        }

        public virtual void Remove(T item)
        {
            if (!Items.Contains(item))
                throw new ArgumentOutOfRangeException(nameof(item));

            Items.Remove(item);
        }

        public virtual void RemoveAll()
        {
            Items.Clear();
        }

        public virtual void Notify(T item)
        {
            foreach (var observer in Observers)
            {
                observer.OnNext(item);
            }
        }

        public virtual void NotifyAll()
        {
            foreach (var item in Items)
            {
                foreach (var observer in Observers)
                {
                    observer.OnNext(item);
                    Remove(item);
                }
            }
        }
    }
}
