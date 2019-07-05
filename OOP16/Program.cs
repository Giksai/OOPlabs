using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace OOP16
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Stopwatch SW = new Stopwatch();
            ////----1-----
            //Task tsk1 = new Task(() =>
            //{
            //    for (int i = 1; i < 300000000 / 3; i ++)
            //    {
            //        int i1 = i;
            //        i = (i * i - i) * (i / i);
            //        i = i1;
            //    }
            //    Console.WriteLine("Выполнена первая задача!");
            //});
            //SW.Start();
            //tsk1.Start();
            //Console.WriteLine("Идентификатор задачи: " + tsk1.Id);
            //if (tsk1.Status.Equals(TaskStatus.Running))
            //{
            //    Console.WriteLine("Завершена ли задача: " + tsk1.IsCompleted);
            //    Console.WriteLine("Статус задачи: " + tsk1.Status);
            //}
            //tsk1.Wait();
            //SW.Stop();
            //Console.WriteLine("Время разоты задачи: " + SW.Elapsed);
            //----2-----
            //CancellationTokenSource csource = new CancellationTokenSource();
            //Task tsk1 = new Task(() =>
            //{
            //    for (int i = 1; i < 300000000 / 3; i ++)
            //    {
            //        int i1 = i;
            //        i = (i * i - i) * (i / i);
            //        i = i1;
            //    }
            //    Console.WriteLine("Выполнена первая задача!");
            //}, csource.Token);
            //tsk1.Start();
            //csource.Cancel();
            //Console.WriteLine("Статус: " + tsk1.Status);
            //-----3----
            //Task<int>[] tasks =
            //{
            //    new Task<int>(() =>
            //    {
            //        return 10*20/4+55-27*3;
            //    }),
            //    new Task<int>(() =>
            //    {
            //        return 1*2*3*4*5*6;
            //    }),
            //    new Task<int>(() =>
            //    {
            //        return 666;
            //    })
            //};
            //foreach (var ob in tasks) ob.Start();
            //Task.WaitAll(tasks);
            //int[] results = new int[3];
            //for (int i = 0; i < 3; i++)
            //    results[i] = tasks[i].Result;
            //Task tsk3 = Task.Run(() => { Method(results); });
            //-----4------

        }

        public static void Method(int[] args)
        {
            foreach(var obj in args) Console.WriteLine(obj);
        }

    }
}
