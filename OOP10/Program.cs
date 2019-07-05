using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace OOP11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //A Создание ArrayList и заполнение случайными числами
            ArrayList arrl = new ArrayList();
            arrl.Capacity = 20; //Задает максимальное число элементов
            Random rand = new Random();
            arrl.Add(1);
            arrl.Add(2);
            for (int i = 0; i < 5; i++) 
            {
                arrl.Add(rand.Next(0, 10));
            }
            //B Добавление строки
            arrl.Add("Строка для листа");
            //C Добавление объекта типа Студент
            arrl.Add(new Student(20, "Дмитрий Васильевич"));
            Student.PrintList(arrl);
            Console.WriteLine("Количество элементов в листе до удаления: " + arrl.Count);
            Console.WriteLine("----------После удаления----------");
            Object obj1 = 1;
            Object obj2 = 2;
            Object obj99 = 99;
            //D Удаление заданного элемента
            arrl.Remove(obj1);
            //E Вывод коллекции и количества элементов
            Student.PrintList(arrl);
            Console.WriteLine("Количество элементов в листе после удаления: "+ arrl.Count);
            //F Поиск значения в коллекции
            Console.WriteLine("ПОИСК:--------");
            Console.WriteLine(arrl.Contains(obj2));
            Console.WriteLine(arrl.Contains(obj99));
            Console.WriteLine("Индекс двойки: "+arrl.IndexOf(obj2));
            //--------------------------------------------------2 часть
            Console.WriteLine("Вторая часть: ----------------------------");
            Stack<double> stk = new Stack<double>();

            for (int i = 0; i < 10; i++)
            {
                stk.Push(rand.Next(0, 200)/rand.Next(1,10));
            }
            //A Вывод коллекции в консоль
            Student.PrintList(stk);
            Console.WriteLine("-----------------После удаления-----------");
            //B Удалении n последовательности элементов
            int n = 4;
            for (int i = 0; i < n; i++)
            {
                stk.Pop();
            }
            Student.PrintList(stk);
            //C  Добавление всеми возможными методами
            //Только push
            //D Создание второй коллекции и заполнение ее значениями старой коллекции
            LinkedList<double> lst = new LinkedList<double>(stk.ToArray());
            Console.WriteLine("Вторая коллекция:");
            //E Вывод второй коллекции в консоль
            Student.PrintList(lst);
            //F Нахождение значения в коллекции
            Console.WriteLine("Содержится 5 в листе: "+lst.Contains(5));
            //-------------------------------------------3 часть
            Console.WriteLine("3 Часть:--------------------------------");
            Stack<Student> stk2 = new Stack<Student>();
            for (int i = 0; i < 5; i++)
            {
                stk2.Push(new Student(rand.Next(0, 10), "Student in stack"));
            }
            //A Вывод коллекции в консоль
            Console.WriteLine("Стек до удаления: ");
            Student.PrintList(stk2);
            //B Удалении n последовательности элементов
            for (int i = 0; i < 2; i++)
            {
                stk2.Pop();
            }
            Console.WriteLine("Стек после удаления: ");
            Student.PrintList(stk2);
            //C Добавление всеми возможными методами
            //Нету других типов
            //D Создание второй коллекции и заполнение ее значениями старой коллекции
            LinkedList<Student> lst2 = new LinkedList<Student>(stk2.ToArray());
            Student stdnt = new Student(20, "STDNT");
            //E Вывод второй коллекции в консоль
            Console.WriteLine("Лист из стека: ");
            lst2.AddLast(stdnt);
            Student.PrintList(lst2);
            //F Нахождение значения в коллекции
            Console.WriteLine($"Содержится студент с возрастом {stdnt.age} и именем {stdnt.name}: " + lst2.Contains(stdnt));
            //-----------------------------------------4 Часть
            var obscol = new ObservableCollection<Student>();
            obscol.CollectionChanged += OnCollectionChange;
            obscol.Add(new Student(30, "123"));

        }

        public static void OnCollectionChange(object sender, EventArgs args)
        {
            Console.WriteLine("Коллекцию изменили!");
        }
    }
} 
