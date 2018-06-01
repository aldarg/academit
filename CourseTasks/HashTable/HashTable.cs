using System;
using System.Collections;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    public class HashTable<T> : ICollection<T>
    {
        private List<T>[] table;
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
                return table.Length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Емкость таблица должна быть больше нуля.");
                }

                if (value != Capacity)
                {
                    if (Count == 0)
                    {
                        table = new List<T>[value];
                    }
                    else
                    {
                        T[] temp = new T[Count];
                        CopyTo(temp, 0);

                        table = new List<T>[value];

                        int oldCount = Count;
                        Count = 0;

                        for (int i = 0; i < oldCount; ++i)
                        {
                            Add(temp[i]);
                        }
                    }

                }
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public HashTable()
        {
            table = new List<T>[10];
        }

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Емкость таблица должна быть больше нуля.");
            }

            table = new List<T>[size];
        }

        private int GetIndex(T item)
        {
            if (item != null)
            {
                return Math.Abs(item.GetHashCode() % Capacity);
            }
            else
            {
                return 0;
            }
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (table[index] == null)
            {
                table[index] = new List<T>
                {
                    item
                };

                ++modCount;
                ++Count;
            }
            else if (!table[index].Contains(item))
            {
                table[index].Add(item);

                ++modCount;
                ++Count;
            }
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (table[index] != null && table[index].Remove(item))
            {
                --Count;
                ++modCount;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            if (Count > 0)
            {
                table = new List<T>[Capacity];

                ++modCount;
                Count = 0;
            }
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            return (table[index] != null && table[index].Contains(item));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Ошибка параметра <array>: ссылка на null.");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new IndexOutOfRangeException("Ошибка параметра <arrayIndex>: выход за границы массива.");
            }

            if (Count == 0)
            {
                throw new NullReferenceException("Таблица пуста.");
            }

            if (array.Length < arrayIndex + Count)
            {
                throw new ArgumentOutOfRangeException("Длины массива с учетом стартового индекса не хватит для копирования.");
            }

            int start = arrayIndex;

            foreach (T item in this)
            {
                array.SetValue(item, start);
                ++start;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int check = modCount;

            for (int i = 0; i < Capacity; ++i)
            {
                if (table[i] != null)
                {
                    foreach (T data in table[i])
                    {
                        if (check != modCount)
                        {
                            throw new InvalidOperationException("Ошибка: во время итераций изменилось число элементов в коллекции.");
                        }

                        yield return data;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
