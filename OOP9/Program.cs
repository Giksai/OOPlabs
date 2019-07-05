using System;

namespace OOP9
{

    class MainClass
    {
        //public static string Func1(string str1, string str2)
        //{
        //    return String.Concat(str1, str2);
        //}
       public static void Main(string[] args)
        {
            User denchik = new User("Дэнчик");
            User neDenchik = new User("Не денчик");

            Prog prog1 = new Prog();
            Prog prog2 = new Prog();

            denchik.Work += prog1.OnVersionUpdate;
            denchik.Work += prog1.OnVersionUpdate;

            denchik.Upgrade += prog1.OnNameChange;

            neDenchik.Upgrade += prog2.OnMessage;
            neDenchik.Upgrade += prog2.OnVersionUpdate;

            neDenchik.Work += prog2.OnNameChange;
            //Тест
            Console.WriteLine("-------");
            denchik.GoToWork();
            Console.WriteLine("-------");
            denchik.UpgradeSoftware();
            Console.WriteLine("-------");
            neDenchik.UpgradeSoftware();
            Console.WriteLine("-------");
            neDenchik.GoToWork();
            Console.WriteLine("-------");
            prog1.OnVersionUpdate(null, null);

            ////-------------------------------------------------/////
            string str1 = "STR1";
            string str2 = "str2";
            string str3 = "s p a c e s";
            string str4 = "symbo";

            Func<string, string> fnc = (string str6) =>  str6.Replace(' ', 'R'); 

            str3 = str3.RemoveSpaces(fnc);

            Console.WriteLine(str3);

            Methods.ConsoleOut(str1, str2, (string str0, string str01) => { Console.WriteLine($"Вывод строк: {str1}, {str2}"); });
            //str2 = str2.ToUpperCase();
            //Console.WriteLine(str2);

            //str3 = str3.RemoveSpaces(delegate (string str)
            //{
            //   return str.Replace(' ', '.');
            //});
            //Console.WriteLine(str3);

            //str4 = str4.AddSymbol('l');
            //Console.WriteLine(str4);


        }

    }



    //public delegate void Delegate1(int a, int b);
    //public delegate double Delegate2(double a);
    //public delegate void DelUniversal(params object[] param);
    //public delegate void Del(int a);
    //public delegate void MegaWrite(string str);

    // static void RandomFunc(int a)
    // {
    //     Console.WriteLine(a);
    // }
    //public void Func1()
    // {}
    //public void Func2(int a) {}
    //public void Func3(object obj1){}
    //public void Func4(TestClass obj2){}
    //public void Func5(params object[] param){}
    //public static void Anon() => Console.WriteLine("Анонимная функция вызвана!");

    //MegaWrite write = Console.WriteLine;
    //Del delegateObj = RandomFunc;
    //delegateObj.Invoke(15);
    //delegateObj(333);
    //DelegateC.Func1(new Delegate1((int a, int b) => Console.WriteLine($"A: {a}, B: {b}")), 20, 10);
    //DelegateC.Func1(new Delegate2(Math.Sin), 0.5D);
    //delegateObj += RandomFunc;
    //delegateObj += RandomFunc;
    //delegateObj += RandomFunc;
    //delegateObj += RandomFunc;
    //delegateObj += RandomFunc;
    //delegateObj(50);
    //delegateObj = delegate (int a)
    //{
    //    Console.WriteLine(a);
    //};
    //delegateObj(228);
    //delegateObj = delegate {
    //    write("Hello");
    //    //delegateObj(1);
    //};
    //delegateObj(111);
    //Delegate2 del2 = (x) => ++x;
    //Console.WriteLine(del2(5));
    //del2 = (y) =>
    //{
    //    return ++y;
    //};
    //Console.WriteLine(del2(5));
    //MegaWrite writei = (k) => Console.WriteLine(k);

    //public class TestClass
    //{
    //    public string Name { get; set; }
    //    TestClass(string name)
    //    {
    //        Name = name;
    //    }
    //}
}
