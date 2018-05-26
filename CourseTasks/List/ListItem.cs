namespace Academits.DargeevAleksandr
{
    internal class ListItem<T>
    {
        private T data;
        private ListItem<T> next;

        internal ListItem(T data)
        {
            this.data = data;
        }

        internal ListItem(T data, ListItem<T> next)
        {
            this.data = data;
            this.next = next;
        }

        internal T GetData()
        {
            return data;
        }

        internal void SetData(T data)
        {
            this.data = data;
        }

        internal ListItem<T> GetNext()
        {
            return next;
        }

        internal void SetNext(ListItem<T> next)
        {
            this.next = next;
        }
    }
}
