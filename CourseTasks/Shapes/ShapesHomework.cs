using System;

namespace Academits.DargeevAleksandr
{
    class ShapesHomework
    {
        public static Shapes GetMaxAreaShape(Shapes[] list, int place)
        {
            Array.Sort(list, new AreaComparer());

            return list[place - 1];
        }

        public static Shapes GetMaxPerimeterShape(Shapes[] list, int place)
        {
            Array.Sort(list, new PerimeterComparer());

            return list[place - 1];
        }

        static void Main(string[] args)
        {
            Shapes[] shapesList = new Shapes[]
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

            foreach (Shapes a in shapesList)
            {
                Console.WriteLine(a);
                Console.WriteLine(a.Equals(shapesList[0]));
            }

            Square test1 = new Square(5);
            Shapes test2 = new Circle(5);

            Console.WriteLine(test1.Equals(test2));

            //TODO переназвать методы
            //TODO задать вопрос про изменение массива - нужно новый создавать?
            Console.WriteLine(GetMaxAreaShape(shapesList, 1));
            Console.WriteLine(GetMaxPerimeterShape(shapesList, 2));
        }
    }
}
