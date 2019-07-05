using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Lab16
{
    public static class Paralleler
    {
        public static void For()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 5000; i++)
            Generate(i); 

            watch.Stop();
            Console.WriteLine("Обычный цикл(For): {0}", watch.Elapsed);
            watch.Start();
            Parallel.For(1, 5000, Generate);
            watch.Stop();
            Console.WriteLine("Параллельный цикл(For): {0}", watch.Elapsed);
        }
        public static void ForEach()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            foreach (int vec in new List<int>() { 10000, 10000 })
            {
                Generate(vec);
            }
            watch.Stop();
            Console.WriteLine("Общий цикл(ForEach): {0}", watch.Elapsed);
            watch.Start();
            ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 10000, 10000 }, Generate);
            watch.Stop();
            Console.WriteLine("Параллельный цикл(ForEach): {0}", watch.Elapsed);
        }
        public static void Generate(int n) //Создание вектора
        {
            Vector vector = new Vector(n);
        }
        public static void DoubleTask(int n)
        {
            Parallel.Invoke(Display, () =>
            {
                Console.WriteLine("(Лямбда выражение) Текущее id 1: {0}", Task.CurrentId);
                Thread.Sleep(300);
                Generate(n);
            },
                                    () => Generate(n));
        }
        private static void Display()
        {
            Console.WriteLine("(метод display) Текущее id 2: {0}", Task.CurrentId);
            Thread.Sleep(30);
        }
    }
}
