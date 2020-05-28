using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace task_2
{
    public static class TimerSamples
    {
        public static void StartExample()
        {
            Console.WriteLine("Current Time: " +DateTime.Now);

            var source = Observable.Timer(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1))
                .Timestamp();
            source.Subscribe(x => Console.WriteLine("{0}: {1}", x.Value, x.Timestamp));
            
                Console.WriteLine("Press any key to unsubscribe");
                Console.ReadKey();
            
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
