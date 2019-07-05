using System;
namespace OOP9
{
    public delegate void OnMSG(object sender, EventClassVars args);
    public delegate void OnNC(object sender, EventClassVars args);
    public class Prog
    {
        public int Version { get; set; }
        public string Name { get; set; }

        public void OnVersionUpdate(object sender, EventArgs args)
        => Console.WriteLine($"Программа под именем {Name="PROG"}, с версией {Version} была обновлена до версии {++Version}");

        public void OnMessage(object sender, EventArgs args)
        =>    Console.WriteLine("Вызвана функция OnMessage");

        public void OnNameChange(object sender, EventArgs args)
        =>    Console.WriteLine("Вызвана функция OnNameChange");

        public OnNC Func2 = (sender, args) =>
        {
            Console.WriteLine($"Вызван обработчик под номером - {args.number}, с сообщением: {args.message}, было вызвано {args.time.Date}");
            Console.WriteLine($"Имя программы было изменено пользователем {args.UserName}, ");
            Console.WriteLine("Вызвано объектом: " + sender);
        };
        public OnMSG Func1 = delegate (object sender, EventClassVars args) {

            Console.WriteLine("Вызван обработчик с сообщением {0}", args.message);
            Console.WriteLine("Вызвано объектом: "+sender);
        };

        public Prog() //Конструктор
        {
            Version = 1;
        }
    }
}
