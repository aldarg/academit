namespace Academits.DargeevAleksandr
{
    internal class ListItem<T>
    {
        internal T Data
        {
            get;
            set;
        }

        internal ListItem<T> Next
        {
            get;
            set;
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
    }
}
