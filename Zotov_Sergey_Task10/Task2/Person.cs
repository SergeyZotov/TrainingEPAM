using System;

namespace Task2
{
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public delegate void OnCame(Person person, DateTime time);
        public delegate void OnGone(Person person);

        public event OnCame Came;
        public event OnGone Gone;

        public void GoToWork()
        {
            
        }

        public void GoHome()
        {

        }

        internal void Hello(Person personWhoAlreadyInOffice, DateTime timeOfCame)
        {
            string whoAlreadyinOffice = personWhoAlreadyInOffice.Name;

            if (timeOfCame.Hour < 12)
            {
                Console.WriteLine($"Доброе утро, {whoAlreadyinOffice}! - сказал {Name}");
            }
            else if (timeOfCame.Hour < 17)
            {
                Console.WriteLine($"Добрый день, {whoAlreadyinOffice}! - сказал {Name}");
            }
            else
            {
                Console.WriteLine($"Добрый вечер, {whoAlreadyinOffice}! - сказал {Name}");
            }
        }

        internal void Goodbye(Person personWhoGone)
        {
            Console.WriteLine($"До свидания, {personWhoGone.Name}! - сказал {Name}");
        }
    }
}
