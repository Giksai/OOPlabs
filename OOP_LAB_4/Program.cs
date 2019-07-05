using System;

namespace OOP_LAB_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List(4);
            list.PrintAll();
            list.AddElement(0);
            list.AddElement(1);
            list.AddElement(2);
            list.AddElement(3);
            list.PrintAll();
        }
    }
}
