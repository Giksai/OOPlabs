using System;
using System.Collections.Generic;
namespace OOP12
{
    public class TopClass : IComparable
    {
        public static int allClasses;
        public int ID { get; set; }
        public int Param;
        public List<string> names;
        public TopClass()
        {
            allClasses++;
            ID = allClasses;
            names = new List<string>();
        }

        public string this[int index]
        {
            get
            {
                return names[index];
            }
            set
            {
                names[index] = value;
            }
        }

        public static void NiceMethod(string b, string a)
        {
            Console.WriteLine($"MethodInvoken, {b} {a}");
        }

        public override string ToString()
        {
            return $"ID : {ID} из {allClasses}, Param: {Param}";
        }

        public int CompareTo(object obj)
        {
            if (names.Count > ((TopClass)obj).names.Count) return 1;
            if (names.Count < ((TopClass)obj).names.Count) return -1;
            return 0;
        }
    }
}
