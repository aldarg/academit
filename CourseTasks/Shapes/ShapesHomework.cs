using System;

namespace Academits.DargeevAleksandr
{
    class ShapesHomework
    {
        public static IShape GetShapeByAreaRating(IShape[] list, int place)
        {
            Array.Sort(list, new AreaComparer());

            return list[place - 1];
        }

        public static IShape GetShapeByPerimeterRating(IShape[] list, int place)
        {
            Array.Sort(list, new PerimeterComparer());

            return list[place - 1];
        }

        static void Main(string[] args)
        {
            IShape[] shapesList = new IShape[]
            {
                new Square(5),
                new Rectangle(3, 4),
                new Circle(3.5),
                new Triangle(1, 1, 2, 4, 6, 0),
                new Circle(2),
                new Square(4.5),
                new Rectangle(1,10),
                new Triangle(0, 0, 3, 0, 0, 4),
            };

            foreach (IShape a in shapesList)
            {
                Console.WriteLine(a);
                Console.WriteLine(a.Equals(shapesList[0]));
            }

            Square test1 = new Square(5);
            IShape test2 = new Circle(5);

            Console.WriteLine(test1.Equals(test2));

            Console.WriteLine(GetShapeByAreaRating(shapesList, 1));
            Console.WriteLine(GetShapeByPerimeterRating(shapesList, 2));
        }
    }
}
