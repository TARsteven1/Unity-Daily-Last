
namespace Pool
{
    using System;
    using System.Collections.Generic;
    public interface IObjectPool<T> where T : class
    {
        void Clear();
        T Get();
        void Put(T element);
    }

    public class ObjectPool<T> : IDisposable, IObjectPool<T> where T : class
    {
        internal readonly Queue<T> m_Queue;
        private Func<T> create;
        private Action<T> getItem;
        private Action<T> putItem;
        private Action<T> destroyItem;
        private Action<T> setParent;
        private readonly int maxSize;

        public ObjectPool(
            Func<T> _create, Action<T> _getItem = null,Action<T> _putItem = null,Action<T> _setParent = null,Action<T> _destroyItem = null,
            int capacity = 10,int _maxSize = 100)
        {
            m_Queue = new Queue<T>(capacity);
            create = _create;
            getItem = _getItem;
            putItem = _putItem;
            setParent = _setParent;
            destroyItem = _destroyItem;
            maxSize = _maxSize;
        }

        public T Get()
        {
            T local = null;
            if (m_Queue.Count == 0)
            {
                local = create();
            }
            else
            {
                local = m_Queue.Dequeue();
            }
            getItem?.Invoke(local);
            return local;
        }

        public void Put(T local)
        {
            if (CalcInactiveAmount() == maxSize)
            {
                destroyItem?.Invoke(local);
            }
            else
            {
                m_Queue.Enqueue(local);
                putItem?.Invoke(local);
                setParent?.Invoke(local);
            }
        }

        public int CalcInactiveAmount()
        {
            return m_Queue.Count;
        }

        public void Clear()
        {
            foreach (T item in m_Queue)
            {
                destroyItem?.Invoke(item);
            }
            m_Queue.Clear();
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
