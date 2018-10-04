namespace ExcelTask
{
    public class Person
    {
        public int Age { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }

        public Person(string firstName, string lastName, int age, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Phone = phone;
        }
    }
}
