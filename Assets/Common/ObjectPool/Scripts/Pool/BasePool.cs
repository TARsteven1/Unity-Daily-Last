
namespace Pool
{
    using System;
    using UnityEngine;
    public interface IBasePool<T> where T : Component
    {
        T Get();
        GameObject GetObject();
        void Put(T element);
        void Put(GameObject element);
        void Clear();
    }

    public class BasePool<T> : IDisposable, IBasePool<T> where T : Component
    {
        protected T prefab;
        IObjectPool<T> pool;
        public BasePool(T _prefab, int maxSize = 100)
        {
            prefab = _prefab;
            pool = new ObjectPool<T>(OnCreate, OnGet, OnPut, OnSetParent, OnDestroy, 10, maxSize);
        }

        protected virtual T OnCreate()
        {
            return UnityEngine.Object.Instantiate(prefab);
        }

        protected virtual void OnGet(T obj)
        {
            obj.gameObject.SetActive(true);
        }

        protected virtual void OnPut(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void OnSetParent(T obj)
        {
            obj.transform.SetParent(PoolDefine.pool_Root, false);
        }

        protected virtual void OnDestroy(T obj)
        {
            UnityEngine.Object.Destroy(obj.gameObject);
        }

        public virtual T Get()
        {
            return pool.Get();
        }

        public virtual GameObject GetObject()
        {
            GameObject local = Get().gameObject;
            return local;
        }

        public virtual void Put(T element)
        {
            pool.Put(element);
        }

        public virtual void Put(GameObject element)
        {
            T local = element.GetComponent<T>();
            Put(local);
        }

        public virtual void Clear()
        {
            pool.Clear();
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
