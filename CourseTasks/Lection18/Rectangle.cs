using System;
using System.Runtime.Serialization;

namespace Academits.DargeevAleksandr
{
    [Serializable]
    public class Rectangle
    {
        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        [NonSerialized]
        public int Area;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;

            Area = width * height;
        }

        [OnDeserialized]
        private void RecoverArea(StreamingContext context)
        {
            Area = Width * Height;
        }
    }
}
