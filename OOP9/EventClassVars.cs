using System;
namespace OOP9
{
    public class EventClassVars : EventArgs
    {
        public int number;
        public string message;
        public string UserName;
        public DateTime time;

        public EventClassVars(int number, string message, string UserName, DateTime time)
        {
            this.number = number;
            this.message = message;
            this.time = time;
            this.UserName = UserName;
        }
    }
}
