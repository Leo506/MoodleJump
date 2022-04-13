using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pooling
{
    public class Pool<T>
        where T : MonoBehaviour
    {
        public bool autoExpand { get; set; }  // Авторасширяемый пул?

        private Transform container;
        private T prefab;
        private List<T> pool;
        private int startCount;

        public Pool(T prefab, int count, Transform container)
        {
            this.prefab = prefab;
            this.container = container;
            this.startCount = count;

            CreatePool();
        }

        private void CreatePool()
        {
            pool = new List<T>();
            for (int i = 0; i < startCount; i++)
                CreateObject();
        }

        private T CreateObject(bool isActive = false)
        {
            T obj;
            if (container != null)
                obj = GameObject.Instantiate(prefab, container);
            else
                obj = GameObject.Instantiate(prefab);

            obj.gameObject.SetActive(isActive);

            pool.Add(obj);

            return obj;
        }

        public T GetFreeElement()
        {
            T element;
            if (HasFreeElement(out element))
            {
                element.gameObject.SetActive(true);
                return element;
            }

            if (autoExpand)
                return CreateObject(true);

            return null;
        }

        private bool HasFreeElement(out T element)
        {
            foreach (var item in pool)
            {
                if (!item.gameObject.activeSelf)
                {
                    element = item;
                    return true;
                }
            }

            element = null;
            return false;
        }
    }
}