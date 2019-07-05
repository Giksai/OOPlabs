using System;
using System.IO;
namespace OOP13
{
    public static class MDYDirInfo
    {
        public static void DirInfo(string path)
        {
            DirectoryInfo DI = new DirectoryInfo(path);
            if (!DI.Exists) throw new Exception("Null reference exception");
            Console.WriteLine($"Вывод информации о директории {DI.Name} :");
            Console.WriteLine("Количество файлов: " + DI.GetFiles().Length);
            Console.WriteLine("Время создания: " + DI.CreationTime);
            Console.WriteLine("Количество поддиректориев: " + DI.GetDirectories().Length);
            Console.WriteLine("Родительский директорий: " + DI.Parent.Name);
        }
    }
}
