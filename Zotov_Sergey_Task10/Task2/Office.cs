using System;
using System.Collections.Generic;

namespace Task2
{

    public delegate void SayHello(Person other, DateTime time);
    public delegate void SayGoodBye(Person other);

    class Office
    {

        private SayHello greetAll;
        private SayGoodBye byeAll;

        private void OnCameEventHandler(Person person, DateTime time)
        {
            Console.WriteLine($"\n[На работу пришел {person.Name}]");
            greetAll?.Invoke(person, time);
            greetAll += person.Hello;
            byeAll += person.Goodbye;
        }
        private void OnGoneEventHandler(Person person)
        {
            Console.WriteLine($"\n[{person.Name} ушел домой]");
            greetAll -= person.Hello;
            byeAll -= person.Goodbye;
            byeAll?.Invoke(person);

        }

        List<Person> people = new List<Person>();

        public void Add(Person person)
        {
            people.Add(person);
            OnCameEventHandler(person, DateTime.Now);
        }

        public void Remove(Person person)
        {
            people.Remove(person);
            OnGoneEventHandler(person);
        }
    }
}
