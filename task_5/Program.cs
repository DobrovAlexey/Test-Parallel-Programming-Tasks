using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace task_5
{
    // Реализовать асинхронный метод, который в качестве аргумента принимает положительное число,
    // а возвращает массив длинной в указанное число, заполненный значениями от 0 до указанного числа
    // Также нужно вызвать тот метод, получить возвращаемое значение и вывести в консоль

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"1) id потока - {Thread.CurrentThread.ManagedThreadId}");

            var result = await MethodAsync(25);

            Console.WriteLine("Длинна масива - " + result.Length);

            foreach (var i in result)
            {
                Console.Write(i +", ");
            }

            Console.WriteLine($"\n4) id потока - {Thread.CurrentThread.ManagedThreadId}");
            Console.Read();
        }

        // определение асинхронного метода
        static async Task<int[]> MethodAsync(int n)
        {
            Console.WriteLine($"2) id потока - {Thread.CurrentThread.ManagedThreadId}");

            return await Task.Run(() =>
            {
                Console.WriteLine($"3) id потока - {Thread.CurrentThread.ManagedThreadId}");

                var range = Enumerable.Range(0, n);
                return range.ToArray();
            });
        }
    }
}
