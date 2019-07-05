using System;
using System.IO;

namespace OOP13
{
    public static class MDYDiskInfo
    {
        public static DriveInfo[] drives = DriveInfo.GetDrives();

        public static void ShowFreeDiskSpace(int disk)
        {

            if (disk > drives.Length || disk<0) throw new Exception("Trying to acces non-existent drive");
            Console.WriteLine($"Free space on drive № {disk}: {drives[disk].TotalFreeSpace/1000000} Mb");
        }

        public static void ShowFileSystemInfo()
        {
            Console.WriteLine("Вывод информаии о файловой системе: ");
            foreach(var obj in drives)
            {
                Console.WriteLine($"File sistem on drive {obj.Name} : {obj.DriveFormat}");
            }
        }

        public static void ShowAllDiskInfo()
        {
            Console.WriteLine("Вывод информации о всех дисках: ");
            foreach(var obj in drives)
            {
                Console.WriteLine("Name: " + obj.Name);
                Console.WriteLine("Volume label: " + obj.VolumeLabel);
                Console.WriteLine("Drive Format " + obj.DriveFormat);
                Console.WriteLine("Free space: " + obj.AvailableFreeSpace/1000000 + " Mb");
                Console.WriteLine("Drive type: " + obj.DriveType);
                Console.WriteLine("Total size: " + obj.TotalSize/1000000 + " Mb");
            }
        }
    }
}
