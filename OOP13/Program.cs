using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.IO.Compression;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Threading;
namespace OOP13
{

    class MainClass
    {
        public static string currDir = Directory.GetCurrentDirectory();


        public static void Main(string[] args)
        {
            try
            {
                FileSystemWatcher fsw = new FileSystemWatcher();
                fsw.Path = Directory.GetCurrentDirectory();
                fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                fsw.Changed += MDYLog.OnChange;
                fsw.Created += MDYLog.OnCreate;
                fsw.Deleted += MDYLog.OnDelete;
                fsw.Renamed += MDYLog.OnRename;

                fsw.EnableRaisingEvents = true;

                StartEvent.Init();
                //------2-------
                //MDYDiskInfo.ShowFreeDiskSpace(0);
                //MDYDiskInfo.ShowFreeDiskSpace(1);
                //MDYDiskInfo.ShowFreeDiskSpace(2);

                //MDYDiskInfo.ShowAllDiskInfo();

                //MDYDiskInfo.PrintFileSystemInfo();

                //MDYDirInfo.DirInfo(currDir);
                //---------

                //-------3-------
                FileInfo fi3 = new FileInfo(currDir + "/321.txt");
                MDYFileInfo.PrintFileInfo(fi3.FullName);
                //---------------

                //-------4------
                MDYDirInfo.DirInfo(currDir);
                //--------------
                //------5------
                MDYFileManager.CreateDirectory("MDYInspect", currDir);
                FileInfo fi1 = MDYFileManager.CreateFileAt("mdydirinfo.txt", currDir);
                Console.WriteLine(fi1.FullName);
                StreamWriter fs1 = File.AppendText(fi1.FullName);
                byte[] buff = Encoding.UTF8.GetBytes("TEXT");
                fs1.Write("TEXT");
                fs1.Flush();
                fs1.Dispose();
                if (!File.Exists(currDir + "/mdydirinfo2.txt"))
                fi1.CopyTo(currDir + "/mdydirinfo2.txt");
                fi1.Delete();

                //---b---
                MDYFileManager.CreateDirectory("MDYfiles", currDir);
                MDYFileManager.CopyAllFilesToDirectory(new DirectoryInfo(currDir), ".txt", "MDYfiles");
                if (!Directory.Exists(currDir+"/MDYInspect/MDYfiles"))
                Directory.Move(currDir + "/MDYfiles", currDir + "/MDYInspect/MDYfiles");

                //-----c----
                if (!File.Exists(currDir + "/TOPZIP.zip"))
                ZipFile.CreateFromDirectory(currDir + "/MDYInspect/MDYfiles", currDir + "/TOPZIP.zip");
                if (!File.Exists(currDir + "/NewDir/321.txt"))
                using (var archive = ZipFile.Open(currDir + "/TOPZIP.zip", ZipArchiveMode.Read))
                {
                    archive.ExtractToDirectory(currDir + "/NewDir");
                }
                //---------

                //--------6--
                MDYLog.DisplayFile();

                //StreamReader stream = File.OpenText(currDir + "MDYlogfile.txt");
                //string text = stream.ReadToEnd();
                //Console.WriteLine(text);
                //-----------

                    MDYLog.SW.Flush();
                MDYLog.SW.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Ну все, пиздец \n");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {

            }
            //DriveInfo[] dinfo = DriveInfo.GetDrives();
            //foreach(var obj in dinfo) 
            //{
            //    Console.WriteLine("-------------");
            //    Console.WriteLine("Имя: " + obj.Name + "\n Volume Label: " + obj.VolumeLabel);
            //    Console.WriteLine("Свободно места (AvailableFreeSpace) " + obj.AvailableFreeSpace/1000/1000);
            //    Console.WriteLine("Drive Type: " + obj.DriveType);
            //    Console.WriteLine("Total size: " + obj.TotalSize/1000/1000);
            //    Console.WriteLine("Total Free Space:  " + obj.TotalFreeSpace/1000/1000);
            //    Console.WriteLine("Is ready: " + obj.IsReady);
            //    Console.WriteLine("Drive format:" + obj.DriveFormat);

            //}
            //----
            //DirectoryInfo dir = Directory.CreateDirectory("/Users/evgenij/Projects/OOP13/bin/Debug/LolDir");
            //DirectoryInfo dir2 = new DirectoryInfo(Directory.GetCurrentDirectory());
            //foreach(var obj in dir2.GetFiles()) Console.WriteLine(obj.Name);
            //Console.WriteLine("--Catalogs--");
            //string[] cats = Directory.GetDirectories(Directory.GetCurrentDirectory());
            //foreach(var obj in cats) Console.WriteLine(obj);
            //Console.WriteLine(Directory.GetParent(Directory.GetCurrentDirectory()));
            //----
            //string path1 = "/Users/evgenij/Projects/OOP13/bin/Debug/123.jpg";
            //string path2 = "/Users/evgenij/Projects/OOP13/bin/Debug/321.txt";
            //FileInfo fi1 = new FileInfo(path1);
            //FileInfo fi2 = new FileInfo(path2);
            //ZipArchive zip1 = ZipFile.Open(Directory.GetCurrentDirectory() + "/ZIPZIP.zip", ZipArchiveMode.Create);
            //using (ZipArchive zip2 = ZipFile.OpenRead(Directory.GetCurrentDirectory()+"/ZIPZIP.zip"))
            //{
            //    foreach (var obj in zip2.Entries)
            //    {
            //        Console.WriteLine(obj.FullName);
            //    }
            //}

        }
    }
}
