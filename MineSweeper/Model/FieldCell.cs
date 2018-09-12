namespace Academits.DargeevAleksandr
{
    internal class FieldCell
    {
        internal bool IsOpened { get; set; }
        internal bool IsMarked { get; set; }
        internal bool IsMined { get; set; }
        internal int AdjacentBombsCount { get; set; }
        internal int X { get; set; }
        internal int Y { get; set; }
    }
}
