using System;
using System.IO;
namespace OOP13
{
    public static class MDYFileInfo
    {
        public static void PrintFileInfo(string path)
        {
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists) throw new Exception("Null reference exception");
            Console.WriteLine($"Вывод информации о файле {fileInfo.Name}: ");
            Console.WriteLine("Путь к файлу: " + fileInfo.DirectoryName);
            Console.WriteLine("Размер: " + fileInfo.Length/1000 + " Kb");
            Console.WriteLine("Расширение: " + fileInfo.Extension);
            Console.WriteLine("Время создания: " + fileInfo.CreationTime);
        }
    }
}
