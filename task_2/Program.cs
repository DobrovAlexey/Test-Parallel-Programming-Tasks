using System;
using System.Reactive.Linq;

namespace task_2
{
    // Сделайте с использованием Rx.Net приложение консольное
    // В качестве аргумента вводятся 2 числа, первое обозначает количество, второе интервал времени
    // Программа производит обратный отсчет от количества до нуля, с указанным интервалом, каждый раз выводя сколько осталось и текущее время

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //ObservableSamples.StartExample();
            //TimerSamples.StartExample();

            var count = IntRead("Введите количество:");
            var timeSpan = IntRead("Введите интервал времени в секундах:");

            var obs = Observable.Generate(
                count,
                i => i >= 0,
                i => i - 1,
                i => i,
                i => TimeSpan.FromSeconds(timeSpan));

            var handle = obs.Subscribe(x => Console.WriteLine($"{x}, {DateTime.Now.ToLongTimeString()}"));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            handle.Dispose();
        }

        public static int IntRead(string message = "Введите число > 0")
        {
            int number;
            do
            {
                Console.WriteLine(message);
            } while (!(int.TryParse(Console.ReadLine(), out number) && number > 0));

            return number;
        }
    }
}
