using System;
using System.Collections.Generic;
using System.Reflection;
using SERIALIZATION;
//-----------------------OOP 14------------
namespace OOP14
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //-----1-----
            var ball1 = new Ball();
            ball1.Pump(3);
            //Console.WriteLine(ball1);
            //вызов сериализации
            ball1 = Serializator.SerializationJSON(ball1, "objectJSON.txt", SerOpType.Serialize);
            //ball1.Play();
            //----2----
            //List<Ball> balls = new List<Ball>();
            //balls.Add(new Ball(0));
            //balls.Add(new Ball(1));
            //balls.Add(new Ball(2));
            //balls.Add(new Ball(3));
            //balls = Serializator.SerializationXML(balls, "objectSXML.xml", SerOpType.Deserialize);
            //-----3-----
            //Serializator.XPATHquery("objectSXML.xml");
            //-----4-----
            //Serializator.XMLLINQquery("objectSXML.xml");

        }
    }
}
//влад лох