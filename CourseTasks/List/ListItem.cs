namespace Academits.DargeevAleksandr
{
    internal class ListItem<T>
    {
        public T Data
        {
            get;
            private set;
        }

        public ListItem<T> Next
        {
            get;
            private set;
        }

        internal ListItem(T data)
        {
            Data = data;
        }

        internal ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }

        internal T GetData()
        {
            return Data;
        }

        internal void SetData(T data)
        {
            Data = data;
        }

        internal ListItem<T> GetNext()
        {
            return Next;
        }

        internal void SetNext(ListItem<T> next)
        {
            Next = next;
        }
    }
}
