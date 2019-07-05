using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab16
{
    class Program
    {
        static Task<int> FactorialAsync(int x)
        {
            int result = 1;
            return Task.Run(() =>
            {
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                return result;
            });
        }
        static async Task DisplayResultAsync()
        {
            int result = await FactorialAsync(25);//await-нужен чтобы приостановить выполнение метода до тех пор,пока эта задача не завершится
            Thread.Sleep(3);
            Console.WriteLine("Факториал числа {0} равен {1}", 25, result);
        }
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        static CancellationToken token = cancelTokenSource.Token;



        static void Main(string[] args)
        {
        
            Console.WriteLine("----1-----"); 
            Tasker.GetTask(999999, 10);
            Tasker.GetTask(9999999, 20);
            Tasker.GetTask(99999, 5);

            Console.WriteLine("----2----"); //Использование токена отмены

            Task task = new Task(() =>
            {
                while(true)
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Задача отменена.");
                    return;
                }

            });
            task.Start();
            cancelTokenSource.Cancel();

            Console.WriteLine("----3и4---");//создание 3 задач и использование их результатов в другой задаче и спользование задачи продолжения

            Tasker.FourSum(new Vector(100), new Vector(20), new Vector(30)).GetAwaiter().GetResult();

            Console.WriteLine("----5---"); //Использование стандартных циклов for, foreach и методов класса Parllel

            Paralleler.For();
            Paralleler.ForEach();

            Console.WriteLine("----6---"); //Использование Parallel.Invoke(распараллеливание блока операторов)

            Paralleler.DoubleTask(100000);

            Console.WriteLine("----7---"); //задачка

            Store.Work();

            Console.WriteLine("----8---"); //Использование async, await

            Task t = DisplayResultAsync();
            t.Wait();
        }
    }
}