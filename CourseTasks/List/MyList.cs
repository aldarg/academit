using System;
using System.Collections;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    public class MyList<T> : IList<T>
    {
        private T[] items;
        private int modCount;

        public int Count
        {
            get;
            private set;
        }

        public int Capacity
        {
            get
            {
                if (items == null)
                {
                    return 0;
                }
                else
                {
                    return items.Length;
                }
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("Вместимость массива не должна быть меньше длины списка.");
                }

                if (value != Capacity)
                {
                    Array.Resize(ref items, value);
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
            get
            {
                return false;
            }
        }

        public void EnsureCapacity(int minCapacity)
        {
            if (minCapacity > Capacity)
            {
                Capacity = minCapacity;
            }
        }

        public void TrimToSize()
        {
            if (Count < Capacity * 0.9)
            {
                Capacity = Count;
            }
        }

        public void Add(T item)
        {
            if (Capacity == 0)
            {
                Capacity += 1;
            }
            else if (Count >= Capacity)
            {
                Capacity *= 2;
            }

            items[Count] = item;
            ++Count;
            ++modCount;
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(items, 0, Count);
                Count = 0;
                ++modCount;
            }
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            if (Capacity == 0)
            {
                Capacity += 1;
            }
            else if (Count >= Capacity)
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

            ++modCount;
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

            ++modCount;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int check = modCount;

            for (int i = 0; i < Count; ++i)
            {
                if (check != modCount)
                {
                    throw new InvalidOperationException("Ошибка: во время итераций изменилось число элементов в списке.");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
