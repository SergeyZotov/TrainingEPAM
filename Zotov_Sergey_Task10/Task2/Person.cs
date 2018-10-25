using System;

namespace Task2
{
    class Person
    {
        public delegate void Greeting(Person person, Person whoCame, MyEventArgs e);

        public delegate void Farewell(Person person, Person whoGone);

        public event Greeting Came;

        public event Farewell Gone;

        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public void Hello(Person person, DateTime time)
        {
            Came?.Invoke(person, this, new MyEventArgs(time));
        }

        public void Goodbye(Person whoGone)
        {
            whoGone.Gone?.Invoke(whoGone, this);
        }
    }
}
