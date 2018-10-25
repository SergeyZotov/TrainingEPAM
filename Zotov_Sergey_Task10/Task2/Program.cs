using System;

namespace Task2
{
    class Program
    {
        public delegate void AllCame(Person person, DateTime time);

        public delegate void SomeOneGone(Person person);

        static void Main(string[] args)
        {
            AllCame allGreeting;
            SomeOneGone allGoodbye;

            Person sergey = new Person("Сергей");
            WhoCame(sergey);
            Console.WriteLine();
            // Факт прихода
            sergey.Came += Privetstvie;
            // Добавление в делегат приветствия
            allGreeting = sergey.Hello;
            // Добавление в делегат прощания
            allGoodbye = sergey.Goodbye;

            Person dima = new Person("Дима");
            WhoCame(dima);
            // Факт прихода
            dima.Came += Privetstvie;
            // Все приветствуют пришедшего
            allGreeting(dima, DateTime.Now);
            // Добавление в делегат приветствия
            allGreeting += dima.Hello;
            // Добавление в делегат прощания
            allGoodbye += dima.Goodbye;
            Console.WriteLine();

            Person sasha = new Person("Саша");
            WhoCame(sasha);
            // Факт прихода
            sasha.Came += Privetstvie;
            // Все приветствуют пришедшего
            allGreeting(sasha, DateTime.Now);
            // Добавление в делегат приветствия
            allGreeting += sasha.Hello;
            // Добавление в делегат прощания
            allGoodbye += sasha.Goodbye;
            Console.WriteLine();

            // Кто ушел
            WhoGone(dima);
            // Удаление из делегата прощания
            allGoodbye -= dima.Goodbye;
            // Удаление из делегата приветствия
            allGreeting -= dima.Hello;
            // Факт ухода
            dima.Gone += Proschanie;
            dima.Came -= Privetstvie;
            // С кем прощаются
            allGoodbye(dima);
            Console.WriteLine();

            // Кто ушел
            WhoGone(sergey);
            // Факт ухода
            sergey.Gone += Proschanie;
            // Удаление из делегата прощания
            allGoodbye -= sergey.Goodbye;
            sergey.Came -= Privetstvie;
            // С кем прощаются
            allGoodbye(sergey);
            Console.WriteLine();

            // Кто ушел
            WhoGone(sasha);
            // Факт ухода
            sasha.Gone += Proschanie;
            sasha.Came -= Privetstvie;
            // Удаление из делегатов
            allGoodbye -= sasha.Goodbye;
            allGreeting -= sasha.Hello;

            Console.ReadKey();
        }

        static void Proschanie(Person whoGone, Person person )
        {
            Console.WriteLine($"До свидания, {whoGone.Name}! - сказал {person.Name}");
        }

        static void Privetstvie(Person whoCame, Person person, MyEventArgs timeOfCame)
        {
            string _whoCame = whoCame.Name;
            string name = person.Name;

            if (timeOfCame.Time.Hour < 12)
            {
                Console.WriteLine($"Доброе утро, {_whoCame}! - сказал {name}");
            }
            else if (timeOfCame.Time.Hour < 17)
            {
                Console.WriteLine($"Добрый день, {_whoCame}! - сказал {name}");
            }
            else
            {
                Console.WriteLine($"Добрый вечер, {_whoCame}! - сказал {name}");
            }
        }

        static void WhoCame(Person person)
        {
            Console.WriteLine($"На работу пришел {person.Name}");
        }

        static void WhoGone(Person person)
        {
            Console.WriteLine($"{person.Name} ушел домой");
        }
    }
}
