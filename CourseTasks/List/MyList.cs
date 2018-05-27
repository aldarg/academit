using System;
using System.Collections;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    public class MyList<T> : IList<T>
    {
        private T[] items = new T[10];

        public int Count
        {
            get;
            private set;
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
            private set;
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
            if (Count == 0)
            {
                if (Capacity > 10)
                {
                    Capacity = 10;
                }
            }
            else if (Count < Capacity * 0.9)
            {
                Capacity = Count;
            }
        }

        public void Add(T item)
        {
            if (item != null)
            {
                if (Count >= Capacity)
                {
                    Capacity *= 2;
                }

                items[Count] = item;
                ++Count;
            }
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(items, 0, Count);
                Count = 0;
            }
        }

        public bool Contains(T item)
        {
            foreach (T check in items)
            {
                if (Equals(check, item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Ошибка параметра <массив>  - null.");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new IndexOutOfRangeException("Параметр <индекс> выходит за границы заданного массива.");
            }

            if (array.Length < arrayIndex + Count)
            {
                throw new ArgumentOutOfRangeException("Длины массива не хватит для копирования списка.");
            }

            if (Count != 0)
            {
                Array.Copy(items, 0, array, arrayIndex, Count);
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Индекс превышает границы списка.");
            }

            if (item == null)
            {
                throw new ArgumentNullException("Аргумент null.");
            }

            if (Count >= Capacity)
            {
                Capacity *= 2;
            }

            if (index == Count)
            {
                items[index] = item;
                ++Count;
            }
            else
            {
                Array.Copy(items, index, items, index + 1, Count - index);
                items[index] = item;
                ++Count;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);

                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Индекс превышает границы списка.");
            }

            if (index == Count - 1)
            {
                --Count;
            }
            else
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
                --Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
