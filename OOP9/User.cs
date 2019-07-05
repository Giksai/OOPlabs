using System;
namespace OOP9
{
    public class User
    {
        public event EventHandler Upgrade;
        public event EventHandler Work;
        public readonly string UserName;

        public static int number;

        public void GoToWork()
        {
            if (Work != null)
                Work(this, new EventClassVars(number, "Go to work, mudilo!", UserName, new DateTime()));
        }
        public void UpgradeSoftware()
        {
            if (Work != null)
                Upgrade(this, new EventClassVars(number, "This software was upgraded!!!", UserName, new DateTime()));
        }
        //public void message(this EventArgs message)
        //{
        //    return;
        //}
        public User(string name)
        {
            UserName = name;
        }

        public override string ToString()
        {
            return $"Объект класса пользователь с именем {UserName}";
        }
    }
}
