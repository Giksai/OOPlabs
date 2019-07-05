using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace OOP15
{
    public class TopClass
    {
       public static void ShowCurrentProcesses()
        {
            Process[] proc = Process.GetProcesses();
            foreach(var pr in proc)
            {
                if (pr.VirtualMemorySize64 == 0) continue;
                Console.WriteLine($"Процесс {pr.Id} :");
                Console.WriteLine("Machine name: " + pr.MachineName);
                Console.WriteLine("Main Window Title: " + pr.MainWindowTitle);
                Console.WriteLine("Process Name: " + pr.ProcessName);
                Console.WriteLine("Base Priority: " + pr.BasePriority);
                Console.WriteLine("Launch time: " + pr.StartTime);
                Console.WriteLine("Processor time: " + pr.TotalProcessorTime);

            }
        }

        public static void DomainTask()
        {
            AppDomain currDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Инфа о текущем домене: ");
            Console.WriteLine("Имя: " + currDomain.FriendlyName);
            Console.WriteLine("Детали конфигурации: " + currDomain.SetupInformation);
            Console.WriteLine("Все сборки, загруженные в домен: ");
            foreach(var obj in currDomain.GetAssemblies())
                Console.WriteLine(obj.FullName);

            AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
            //Assembly assembly = newDomain.Load("AssemblyInfo.cs");
            AppDomain.Unload(newDomain);
        }

        public static void ThirdTask()
        {
            Console.WriteLine("Введите количество циклов: ");
            int n = int.Parse(Console.ReadLine());
            if (File.Exists("file.txt")) File.Delete("file.txt");
                for (int i = 0; i < n; i++)
                {
                    File.AppendAllText("file.txt", i.ToString() + "\n");
                Console.WriteLine(i.ToString());
                }
        }


    }
}
