using System;
using System.Linq;
using System.Collections.Generic;
namespace OOP11
{


    class MainClass
    {
        public static Random ran = new Random();
        public static void Main(string[] args)
        {
            string[] months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            Console.WriteLine("Исходная коллекция: ");
            foreach(var obj in months) Console.Write(obj+ " ");
            IEnumerable<string> ieMon = months.Where(n => n.Length == 5).Select(n => n);
            Console.WriteLine("Строки с длиной 5");
            foreach (var obj in ieMon) Console.Write(obj + " ");
            Console.WriteLine();
            IEnumerable<string> ieMon1 = months.SummerWinter();
            Console.WriteLine("Летние и зимние месяцы: ");
            foreach(var obj in ieMon1) Console.Write(obj+ " ");
            Console.WriteLine();
            IEnumerable<string> ieMon2 = from n in months
                                         orderby n
                                         select n;
            Console.WriteLine("Сортированный массссив: ");
            foreach (var obj in ieMon2) Console.Write(obj + " ");
            Console.WriteLine();
            IEnumerable<string> ieMon3 = from n in months
                                         where n.Contains("u")
                                                    where n.Length >= 4
                                         select n;
            Console.WriteLine("Строки, содержащие букву 'u' и длиною не менее 4");
            foreach(var obj in ieMon3) Console.Write(obj + " ");
            Console.WriteLine();
            //-------------------------------2 Создание параметризированной коллекции
            List<TopClass> topl = new List<TopClass>
            {
                new TopClass(),
                new TopClass(),
                new TopClass(),
                new TopClass(),
                new TopClass(),
                new TopClass(),
                new TopClass(),
                new TopClass()
            };
            Console.WriteLine("Исходный Лист:");
            foreach(var obj in topl) Console.Write(obj +" сумма: " + obj.Sum()+ " \n");
            //-------------------------------3 Куча заданий по варианту
            //Массивы только с четными элементами:
            IEnumerable<TopClass> ienum1 = from n in topl
                    where n.CheckEven()
                                 select n;
            Console.WriteLine("Коллекции с четными элементами: ");
            foreach(var obj in ienum1) Console.Write(obj + " ");
            Console.WriteLine();
            //----Массив с наибольшей суммой элементов
            IEnumerable<TopClass> ienum2 = from n in topl
                                           orderby n.Sum()
                                           select n;

            IEnumerable<TopClass> ienum3 = ienum2.Skip(ienum2.Count() - 1);
            Console.WriteLine("Элемент с наибольшей суммой элементов: ");
            foreach(var obj in ienum3) Console.Write(obj + " сумма: " + obj.Sum() + " \n");
            Console.WriteLine();
            //----- Минимальный массив
            IEnumerable<TopClass> ienum4 = ienum2.Take(1);
            Console.WriteLine("Минимальный массив: ");
            foreach(var obj in ienum4) Console.Write(obj + " Сумма: " + obj.Sum() + "\n");
            //----- Количество массивов, содержащих заданное значение
            TopClass tpclass = new TopClass();
            Console.WriteLine("Введите заданные значения: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Введите {i} значение: ");
                                tpclass.lint[i] = (int.Parse(Console.ReadLine()));
            }
            IEnumerable<TopClass> ienum5 = from n in topl
                                           where n.Equals(tpclass)
                                           select n;
            Console.WriteLine("Количество совпадающих массивов: " + ienum5.Count());
            //--------- Количество равных массивов
            int before = topl.Count;
            IEnumerable<TopClass> ienum6 = topl;
            IEnumerable<TopClass> ienum7 = ienum6.Distinct();
            int after = topl.Count;
            Console.WriteLine("Количество повторяющихся элементов: "+(before-after));
            //-------Упорядоченный массив массивов по первому элементу
            IEnumerable<TopClass> ienum8 = from obj in topl
                orderby obj.lint[0]
                                           select obj;
            Console.WriteLine("Упорядоченный массив массивов: ");
            foreach(var obj in ienum8) Console.WriteLine(obj);
            //------4-------
            IEnumerable<int> numbers1 = Enumerable.Range(0, 10);
            IEnumerable<int> numbers2 = Enumerable.Range(5, 10);
            IEnumerable<int> ienum9 = from obj in topl //1
                                           where obj.Sum() > 0 //2
                                           where numbers1.Intersect(numbers2).Intersect(obj.lint).Sum() > 1
                                           where numbers1.OfType<int>().Sum() > 0
                                                    select obj.lint[1];


            //-----5------
                
            var coll1 = new[]
            {
                new {name = "name1", id = 1},
                new {name = "name2", id = 2}
            };
            var coll2 = new[]
            {
                new {name = "name3", id = 1},
                new {name = "name4", id = 3}
            };

            var coll3 = coll1.Join(
            coll2,
                a => a.id,
                b => b.id,
                (a, b) => new
                {
                name = a.name, id = a.id
            }
            );
            Console.WriteLine("JOIN collection:");
            foreach (var item in coll3)
            {
                Console.WriteLine(item);
            }

        }
    }
}
