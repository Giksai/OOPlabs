using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
//    ∆
//   ∆˚∆
namespace OOP15
{
    class intH
    {
        public int i;
    }
    class MainClass
    {
        public static readonly Barrier barr = new Barrier(2);
        public static SemaphoreSlim sem = new SemaphoreSlim(1);
        public static intH count = new intH();
        public static bool EvenFlag = true; //Определяет какой поток будет работать
        public static string EvenName = "EVEN THREAD";
        public static string OddName = "ODD THREAD";
        public static FileStream fs1 = File.Open("file1.txt", FileMode.Create);
        public static FileStream fs2 = File.Open("file2.txt", FileMode.Create);

        public static void Main(string[] args)
        {
            //---1----
            //TopClass.ShowCurrentProcesses();
            //---2---
            //TopClass.DomainTask();
            //----3----
            //Thread thr = new Thread(TopClass.ThirdTask)
            //{
            //    Priority = ThreadPriority.Lowest
            //};
            //thr.Name = "Четкий поток";
            //thr.Start();
            //Thread.Sleep(5000);
            //thr.Suspend();
            //Console.WriteLine("Вывод статуса о выполнении:");
            //Console.WriteLine("Имя потока: " + thr.Name);
            //Console.WriteLine("Приоритет: " + thr.Priority);
            //Console.WriteLine("Выполняется: " + thr.IsAlive);
            //Thread.Sleep(4000);
            //thr.Resume();
            //---4---
            //Thread thrEven = new Thread(FourthTaskA);
            //Thread thrOdd = new Thread(FourthTaskA);
            //thrEven.Name = EvenName;
            //thrOdd.Name = OddName;
            //thrOdd.Priority = ThreadPriority.Lowest;
            //thrEven.Priority = ThreadPriority.Highest;
                    //thrEven.Start();
                    //thrOdd.Start();
             //-----5-----


        }


        public static void FourthTaskA()
        {
            Console.WriteLine("Последовательно четное, затем нечетное");
            for (; count.i < 100;)
            {
                lock(count)
                {
                    if (Thread.CurrentThread.Name == EvenName && EvenFlag || 
                        Thread.CurrentThread.Name == OddName && !EvenFlag)
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.Name}, count: {count.i}");
                        byte[] bytes = Encoding.UTF8.GetBytes($"Thread {Thread.CurrentThread.Name}, count: {count.i} \n");
                        fs1.Write(bytes, 0, bytes.Length);
                        count.i++;
                        EvenFlag = !EvenFlag;
                    }
                }
            }
            //Thread.Sleep(100);
            barr.SignalAndWait();
            Console.WriteLine("Сначала четные, затем нечетные");
            if (Thread.CurrentThread.Name == OddName) Thread.Sleep(100);
            lock(count)
            {
                if (Thread.CurrentThread.Name == EvenName) count.i = 0;
                else count.i = 1;
                for (; count.i < 100; count.i += 2)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.Name}, count: {count.i}");
                    byte[] bytes = Encoding.UTF8.GetBytes($"Thread {Thread.CurrentThread.Name}, count: {count.i} \n");
                    fs2.Write(bytes, 0, bytes.Length);
                }
            }


        }
    }
}



































































































































































//Михайловский даниил ©