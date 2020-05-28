using System;
using System.Threading;
using System.Threading.Tasks;

namespace task_3
{
    // Реализовать тестовый пример в котором будет производится следующие операции
    // 1. Создается и запускается задача (Task)
    // 2. Основной поток ждет 1 секунду - Thread.Sleep(1000)
    // 3. Происходит вызов завершения задачи (Task)
    // Создаваемый Task должен выполнять простую циклическую задачу, пока не будет прерван, например проходит бесконечный цикл, в теле которого проеряется не прервана ли задача
    // Вызов завершения задачи (Task) должен проидить через CancellationTokenSource

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"начало id потока - {Thread.CurrentThread.ManagedThreadId}");

            var cancelTokenSource = new CancellationTokenSource();


            Task task1 = new Task(() => Display(cancelTokenSource.Token));
            task1.Start();


            Thread.Sleep(1000);
            cancelTokenSource.Cancel();

            Console.WriteLine($"конец id потока - {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();
        }

        static void Display(CancellationToken token)
        {
            Console.WriteLine($"таска id потока - {Thread.CurrentThread.ManagedThreadId}");

            while(!token.IsCancellationRequested)
            {
                Console.WriteLine($"цикл id потока - {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
}