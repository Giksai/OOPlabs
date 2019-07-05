using System;
using System.IO;
namespace OOP13
{
    public class MDYFileManager
    {
        public MDYFileManager()
        {
        }

        public static void ReadFiles(int disk)
        {
            if (disk > MDYDiskInfo.drives.Length) throw new Exception("Index out of range");
            DirectoryInfo dir = MDYDiskInfo.drives[disk].RootDirectory;
            Console.WriteLine($"Вывод файлов корневого директория диска {disk} : ");
            foreach(var obj in dir.GetFiles())
            {
                Console.WriteLine(obj.Name);
            }
        }

        public static DirectoryInfo CreateDirectory(string name, string path)
        {

            DirectoryInfo dir = new DirectoryInfo(path + "/" + name);
            if (!Directory.Exists(path + "/" + name))
                dir.Create();
            return dir;
        }

        public static void CopyAllFilesToDirectory(DirectoryInfo dir, string extension, string newDir)
        {
            if ((dir == null) || (newDir == null)) throw new Exception("Директорий не существует");
            foreach (var obj in dir.GetFiles())
            {
                if (obj.Extension == extension)
                if (!File.Exists(dir.FullName + "/" + newDir + "/" + obj.Name))
                    obj.CopyTo(dir.FullName+"/"+newDir+"/"+obj.Name);
            }
        }

        public static FileInfo CreateFileAt(string fileName, string path)
        {
            FileInfo FI = new FileInfo(path + "/" + fileName);
            return FI;
        }
    }
}
