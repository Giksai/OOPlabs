using System;
using System.Collections;
namespace OOP11
{
    public class Student : IComparer, IComparable
    {
        public readonly string name;
        public int age;
        public Student()
        {
            age = 10;
            name = "Maksim";
        }
        public Student(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public override string ToString()
        {
            return $"Студент с возрастом {age}, имя: {name}";
        }

        public static void PrintList<T>(T arrl) where T : IEnumerable
        {
            foreach(var obj in arrl)
            {
                if (obj is Int32 || obj is double)
                    Console.Write(obj+ "  ");
                else
                    Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

        public int Compare(object obj1, object obj2)
        {
            if (!(obj1 == null) && !(obj2 == null))
                if ((obj1 is Student) && (obj2 is Student))
                {
                    if ((obj1 as Student).age > (obj2 as Student).age) return 1;
                    if ((obj1 as Student).age < (obj2 as Student).age) return -1;
                    return 0;
                }
            return 0;
        }

        public int CompareTo(object obj)
        {
            if (obj != null)
                if (obj is Student)
                {
                    if (age > (obj as Student).age) return 1;
                    if (age < (obj as Student).age) return -1;
                    return 0;
                }
            return 0;
        }

    }
}
