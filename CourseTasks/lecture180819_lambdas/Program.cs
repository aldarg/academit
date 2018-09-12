using System;

namespace Academits.DargeevAleksandr
{
    class Program
    {
        static void Main(string[] args)
        {
            int variable = 1;
            Action f = delegate ()
            {
                Console.WriteLine(variable);
                variable = 3;
            };

            f();
            Console.WriteLine(variable);
        }
    }
}
