using System;
using System.Diagnostics;
using System.IO;

namespace OOP13
{
    public static class MDYLog
    {
        public static string logFName = "MDYlogfile.txt";
        public static string fullPath = MainClass.currDir + "/" + logFName;
        public static FileInfo file = new FileInfo(fullPath);
        public static StreamWriter SW;
        public static StreamReader SR;

        public static void Init()
        {
            if (!file.Exists)
               file.Create();
            else File.WriteAllText(fullPath, "");
            SW = File.AppendText(fullPath);

        }

        public static void DisplayFile()
        {
            SW.Dispose();
            SW.Close();
            SR = File.OpenText(fullPath);
            Console.WriteLine("Содержимое лога: ");
            string buff = SR.ReadToEnd();
            //Console.WriteLine(buff);
            //За определенный день:
            string[] logs = buff.Split('\n');
            string[] dates = new string[logs.Length];
            string[] hours = new string[logs.Length];
            int currHour = DateTime.Now.Hour;
            Console.WriteLine("CURRENT HOUR: " + currHour);
            string newLog = new string(new char[500]);
            Console.WriteLine("Количество записей лога: " + logs.Length);
            for (int i = 0; i < logs.Length-1; i++) //Получение массива дат
            {
                dates[i] = logs[i].Split(',')[2].Split(' ')[0];
            }
            Console.WriteLine("Вывод записей лога, сделанных в определенную дату: ");
            for (int i = 0; i < dates.Length-1; i++) //Вывод записей лога, сделанных в определенную дату
            {
                if (int.Parse(dates[i]) == 18) Console.WriteLine(logs[i]);
            }
            for (int i = 0; i < logs.Length-1; i++)//Получение массива часов 
            {
                hours[i] = logs[i].Split(',')[2].Split(' ')[1];
            }
            for (int i = 0; i < hours.Length-1; i++)
            {
                if (int.Parse(hours[i]) == currHour) newLog += logs[i] + "\n";
            }
            Console.WriteLine("Вывод записей лога, сделанных в текущий час: ");
            Console.WriteLine(newLog);
            SR.Dispose();
            SR.Close();
            File.Delete(fullPath); //Удаление лога и заполнение его теми записями, которые были сделаны в текущий час
            file = new FileInfo(fullPath);
            SW = File.AppendText(fullPath);
            SW.Write(newLog);
            SW.Flush();

        }

        public static void OnRename(object sender, RenamedEventArgs args)
        {
            SW.Write($"{DateTime.Now.ToString("yyyy,MM,dd HH:mm:ss")}-File was renamed:{args.Name}\n");
            SW.Flush();
        }

        public static void OnDelete(object sender, FileSystemEventArgs args)
        {
            SW.Write($"{DateTime.Now.ToString("yyyy,MM,dd HH,mm,ss")}-File was deleted:{args.Name}\n");
            SW.Flush();
        }

        public static void OnChange(object sender, FileSystemEventArgs args)
        {
            if (args.Name!="MDYlogfile.txt")
                SW.Write($"{DateTime.Now.ToString("yyyy,MM,dd HH,mm,ss")}-File was changed:{args.Name}\n");
            SW.Flush();
        }

        public static void OnCreate(object sender, FileSystemEventArgs args)
        {
            SW.Write($"{DateTime.Now.ToString("yyyy,MM,dd HH,mm,ss")}-File was created:{args.Name}\n");
            SW.Flush();
        }
    }
}
