using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    public class MyList<T> : IList<T>
    {
        private T[] items = new T[10];

        public int Count
        {
            get;
        }

        public int Capacity
        {
            get
            {
                return items.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("Вместимость массива не должна быть меньше длины списка.");
                }

                if (value != Capacity)
                {
                    T[] newArray = new T[value];

                    Array.Copy(items, 0, newArray, 0, Count);

                    items = newArray;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Индекс вне границ списка.");
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Индекс вне границ списка.");
                }

                items[index] = value;
            }
        }

        public MyList()
        {
        }

        public MyList(int capacity)
        {
            items = new T[capacity];
        }

        public bool IsReadOnly
        {
            get;
        }

        public void EnsureCapacity(int minCapacity)
        {
            if (minCapacity > Capacity)
            {
                int result = (Count == 0) ? 10 : Count * 2;

                if (result < minCapacity)
                {
                    result = minCapacity;
                }

                Capacity = result;
            }
        }

        public void TrimToSize()
        {
            //TODO
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
