using System;
using System.Linq;
using System.Threading;

namespace task_1
{
    // Реализовать простое консольное приложение, которое будет:
    // 1. запускаться
    // 2. требовать ввести целое число
    // 3. В отдельном потоке Thread производить суммирование от 0 до введенного числа. Если число отрицательное, то суммирование от введенного числа до 0.
    // 4. Выводить результат суммирования

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"1) id потока - {Thread.CurrentThread.ManagedThreadId}");

            int number;
            do
            {
                Console.WriteLine("Write the number");
            } while (!int.TryParse(Console.ReadLine(), out number));

            // создаем новый поток
            var myThread = new Thread(Sum);
            myThread.Start(number); // запускаем поток

            Console.WriteLine($"3) id потока - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Конец программы");
            Console.ReadLine();
        }

        public static void Sum(object number)
        {
            Console.WriteLine($"2) id потока - {Thread.CurrentThread.ManagedThreadId}");

            var result = 0;
            var range = Enumerable.Range((int)number, Math.Abs((int)number));

            // параллельная обработка
            range.AsParallel().ForAll(x =>
            {
                Console.WriteLine(
                    $"Прибавляем число - {x}, итог - {result += x}, текущий поток - {Thread.CurrentThread.ManagedThreadId}");
            });

            Console.WriteLine($"4) id потока - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Итог сложения {result}");
        }
    }
}