using System;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
namespace OOP12
{
    public class Reflector
    {
        public static string filename = "classInfo.txt";
        //---1---
        public static void WriteMembersClassToFile(string className)
        {
            Type classType = Type.GetType("OOP12." + className, false, true);
            using(FileStream fs = new FileStream(filename, FileMode.Create))
            {
                foreach (var obj in classType.GetMembers()) fs.Write(Encoding.UTF8.GetBytes(obj.Name + "\n"), 0, obj.Name.Length+"\n".Length);
            }
        }
        //---2----
        public static void PrintPublicMethods(string className)
        {
            Type classType = Type.GetType("OOP12." + className, false, true);
            Console.WriteLine($"Открытые методы класса {className}: ");
            foreach(var obj in classType.GetMethods())
                Console.WriteLine(obj.Name + "\n");
        }
        //-----3----
        public static void PrintFieldsAndProperties(string className)
        {
            Type classType = Type.GetType("OOP12." + className, false, true);
            Console.WriteLine($"Поля класса {className}: ");
            FieldInfo[] fi = classType.GetFields();
            PropertyInfo[] pi = classType.GetProperties();
            for (int i = 0; i < fi.Length; i++)
            {
                Console.WriteLine(fi[i].Name + "\n");
            }
            Console.WriteLine("Свойства: ");
            for (int i = 0; i < pi.Length; i++)
            {
                Console.WriteLine(pi[i].Name + "\n");
            }

        }
        //---4---
        public static void PrintInterfaces(string className)
        {
            Type classType = Type.GetType("OOP12." + className, false, true);
            Console.WriteLine($"Интерфейсы класса {className}: ");
            foreach(var obj in classType.GetInterfaces())
                Console.WriteLine(obj.Name);
        }
        //---5---
        public static void PrintSpecifiedMethods(string className, Type paramType)
        {
            Console.WriteLine($"Имена методов, содержащие параметр {paramType.Name}: ");
            foreach(var obj in Type.GetType("OOP12." + className).GetMethods())
                foreach(var param in obj.GetParameters())
            {
                if (param.ParameterType == paramType) Console.WriteLine(obj.Name);
            }
        }
        //----6----
        public static void InvokeMethod(string className, string methodName)
        {
            byte[] buff = new byte[999];
            using(FileStream fs = new FileStream("params.txt", FileMode.Open))
            {
                fs.Read(buff, 0, 999);
            }
            string[] paramS = Encoding.UTF8.GetString(buff).Split(',');
            Type.GetType("OOP12." + className).GetMethod(methodName).Invoke(null, paramS);
        }
    }
}
