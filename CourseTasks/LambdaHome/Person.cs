using System;

namespace Academits.DargeevAleksandr
{
    class Person
    {
        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, int age)
        {
            Name = name;

            if (age <= 0)
            {
                throw new ArgumentOutOfRangeException("Возраст не может быть меньше 0.");
            }
            else
            {
                Age = age;
            }
        }
    }
}
