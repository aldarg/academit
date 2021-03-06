﻿using System;

namespace Academits.DargeevAleksandr
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        public int Count
        {
            get;
            private set;
        }

        public SinglyLinkedList()
        {
        }

        public SinglyLinkedList(T data)
        {
            AddFirst(data);
        }

        public T GetFirstData()
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст.");
            }
            else
            {
                return head.Data;
            }
        }

        private ListItem<T> GetElement(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Индекс элемента не должен быть меньше нуля или больше длины списка.");
            }

            ListItem<T> item;

            int i = 0;

            for (item = head; item != null; item = item.Next)
            {
                if (i == index)
                {
                    break;
                }

                i++;
            }

            return item;
        }

        public T GetData(int index)
        {
            return GetElement(index).Data;
        }

        public T SetData(int index, T data)
        {
            ListItem<T> item = GetElement(index);

            T oldData = item.Data;
            item.Data = data;

            return oldData;
        }

        public void Add(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Индекс элемента не должен быть меньше нуля и не должен превышать длину списка более чем на единицу.");
            }

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                ListItem<T> item = new ListItem<T>(data);
                ListItem<T> prev = GetElement(index - 1);

                item.Next = prev.Next;
                prev.Next = item;
                Count++;
            }
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Индекс элемента не должен быть меньше нуля или больше длины списка.");
            }

            if (index == 0)
            {
                return RemoveFirst();
            }
            else
            {
                ListItem<T> prev = GetElement(index - 1);
                ListItem<T> item = prev.Next;

                T oldData = item.Data;
                prev.Next = item.Next;
                Count--;

                return oldData;
            }
        }

        public void AddFirst(T data)
        {
            ListItem<T> firstItem = new ListItem<T>(data);

            firstItem.Next = head;
            head = firstItem;
            Count++;
        }

        public T RemoveFirst()
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст.");
            }

            T data = head.Data;
            head = head.Next;
            Count--;

            return data;
        }

        public bool RemoveByValue(T data)
        {
            for (ListItem<T> item = head, prev = null; item != null; prev = item, item = item.Next)
            {
                if (Equals(item.Data, data))
                {
                    if (prev == null)
                    {
                        head = item.Next;
                    }
                    else
                    {
                        prev.Next = item.Next;
                    }

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public void Mirror()
        {
            if (head == null)
            {
                return;
            }

            ListItem<T> next;

            for (ListItem<T> item = head.Next, prev = head; item != null; prev = item, item = next)
            {
                next = item.Next;
                item.Next = prev;

                if (prev == head)
                {
                    prev.Next = null;
                }

                if (next == null)
                {
                    head = item;
                }
            }
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> copy = new SinglyLinkedList<T>();

            if (Count == 0)
            {
                return copy;
            }

            copy.AddFirst(head.Data);
            ListItem<T> copyItem = copy.head;

            for (ListItem<T> item = head.Next; item != null; item = item.Next)
            {
                copyItem.Next = new ListItem<T>(item.Data);
                copyItem = copyItem.Next;
            }

            copy.Count = Count;

            return copy;
        }
    }
}
