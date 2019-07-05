using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace OOP14
{
    public interface ITopInterface
    {
        int ID { get; set; }
        void Pump(int hardness);
    }
    [Serializable][DataContract]
    public abstract class Inventory : ITopInterface
    {
        [DataMember]
        public int ID { get; set; }                 //Порядковый номер объекта мяча
        [DataMember]
        public abstract int Pressure { get; set; }  //Давление мяча
        [DataMember]
        public List<int> list;
        [DataMember]
        public List<Ball> list1;
        [DataMember]
        public Ball ball1;
        public virtual void Pump(int hardness)      //Накачка мяча
        {
            if (hardness < 0 || hardness > 100) throw new Exception("Неверно указан аргумент функции");
            Pressure += hardness;
        }
        public virtual void Play() 
        {
            switch(Pressure)
            {
                case 0:
                    Console.WriteLine("Мяч остался на земле");
                    break;
                case 1:
                    Console.WriteLine("Мяч упал и сдулся");
                    Pressure--;
                    break;
                case 2:
                    Console.WriteLine("Мяч подпрыгнул на 100 метров");
                    Pressure--;
                    break;
                default:
                    Console.WriteLine("Мяч улетел в небо");
                    Pressure--;
                    break;
            }
        }
    }
    [Serializable][DataContract]
    public class Ball : Inventory
    {
        [DataMember]
        public override int Pressure { get; set; } //Давление мяча
        [DataMember]
        public static int AmountOfBalls; //Количество созданных мячей
        [NonSerialized]
        public const bool isRound = true; //Круглый ли мяч (постоянное значение)

        public Ball() 
        {
            ball1 = new Ball(5);
            list = new List<int>
            {
                1,2,3,4,5,6,7
            };
            list1 = new List<Ball>
            {
                new Ball(1),
                new Ball(2),
                new Ball(3)
            };
            AmountOfBalls++;
            ID = AmountOfBalls;
            Pressure = 0;
            Console.WriteLine("Вызван конструктор без параметров");
        }

        public Ball(int pressure)
        {
            if (pressure < 0 || pressure > 100) throw new Exception("Неверно задано давление мяча");
            AmountOfBalls++;
            ID = AmountOfBalls;
            Pressure = pressure;
            Console.WriteLine("Вызван конструктор с параметрами");
        }

        [OnSerialized]
        void Serialized(StreamingContext context)
        {
            Console.WriteLine("OBJECT SERIALIZED");
        }
        [OnDeserialized]
        void Deserialized(StreamingContext context)
        {
            Console.WriteLine("OBJECT DESERIALIZED");
        }

        public override string ToString()
        {
            return $"Мяч с давлением: {Pressure} и с ID: {ID}";
        }


    }
}
