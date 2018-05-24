using System;

namespace Academits.DargeevAleksandr
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        public int Length
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

        public T GetDataFirst()
        {
            if (head != null)
            {
                return head.GetData();
            }
            else
            {
                throw new NullReferenceException("Список пуст.");
            }
        }

        private ListItem<T> GetElement(int index)
        {
            if (index < 0 || index > Length - 1)
            {
                throw new IndexOutOfRangeException("Индекс элемента не должен быть меньше нуля или больше длины списка.");
            }

            ListItem<T> item = null;

            int i = 0;

            for (item = head; item != null; item = item.GetNext())
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
            return GetElement(index).GetData();
        }

        public T SetData(int index, T data)
        {
            T oldData = GetElement(index).GetData();

            GetElement(index).SetData(data);

            return oldData;
        }

        public void Add(int index, T data)
        {
            ListItem<T> firstItem = new ListItem<T>(data);

            firstItem.SetNext(GetElement(index));
            GetElement(index - 1).SetNext(firstItem);

            Length++;
        }

        public T Remove(int index)
        {
            T oldData = GetElement(index).GetData();

            GetElement(index - 1).SetNext(GetElement(index + 1));

            Length--;

            return oldData;
        }

        public void AddFirst(T data)
        {
            ListItem<T> firstItem = new ListItem<T>(data);

            firstItem.SetNext(head);
            head = firstItem;

            Length++;
        }

        public T RemoveFirst()
        {
            T data = head.GetData();

            head = head.GetNext();

            Length--;

            return data;
        }

        public bool RemoveByValue(T data)
        {
            for (ListItem<T> item = head, prev = null; item != null; prev = item, item = item.GetNext())
            {
                if (item.GetData().Equals(data))
                {
                    if (prev != null)
                    {
                        prev.SetNext(item.GetNext());
                    }
                    else
                    {
                        head = item.GetNext();
                    }

                    Length--;

                    return true;
                }
            }

            return false;
        }

        public void Mirror()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                SetData(i, SetData(Length - 1 - i, GetData(i)));
            }
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> copy = new SinglyLinkedList<T>();

            for (ListItem<T> item = head; item != null; item = item.GetNext())
            {
                copy.AddFirst(item.GetData());
            }

            copy.Mirror();

            return copy;
        }

        public SinglyLinkedList<T> FullCopy()
        {
            SinglyLinkedList<T> copy = new SinglyLinkedList<T>();

            for (ListItem<T> item = head; item != null; item = item.GetNext())
            {
                copy.AddFirst(item.GetData());
            }

            copy.Mirror();

            for (ListItem<T> item = head, copyItem = copy.head; item != null; item = item.GetNext(), copyItem = copyItem.GetNext())
            {
                if (item.GetOther() != null)
                {
                    copyItem.SetOther(item.GetOther());
                }
            }

            return copy;
        }
    }
}
