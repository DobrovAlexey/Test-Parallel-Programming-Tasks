using System;
using System.Reactive.Linq;

namespace task_2
{
    public static class ObservableSamples
    {
        public static void StartExample()
        {
            IObservable<int> source = Observable.Range(1, 10);
            IDisposable subscription = source.Subscribe(
                x => Console.WriteLine($"OnNext: {x}"),
                ex => Console.WriteLine($"OnError: {ex.Message}"),
                () => Console.WriteLine("OnCompleted"));

            Console.WriteLine("Press ENTER to unsubscribe...");
            Console.ReadLine();
            subscription.Dispose();
        }
    }
}