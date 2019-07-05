using System;
using System.Collections.Generic;
using System.Collections;
namespace OOP11
{
    public class TopClass : IEnumerable, IComparable, IEquatable<TopClass>
    {
        public static int id;
        public int selfID;
        public List<int> lint;


        public TopClass()
        {
            lint = new List<int>();
            id++;
            selfID = id;
            Randomize(ref lint);
        }
        public TopClass(int a, int b, int c)
        {
            lint = new List<int>();
            lint.Add(a);
            lint.Add(b);
            lint.Add(c);
            id++;
            selfID = id;
        }

        public override string ToString()
        {
            string rstring = $"id: {selfID} \n";
            foreach(var obj in lint)
            {
                rstring += obj;
                rstring += " ";
            }
            return rstring;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (int val in lint)
            {
                yield return val;
            }
        }

        public TopEnum GetEnumerator()
        {
            return new TopEnum(lint);
        }

        public bool CheckEven() //Проверяет на четность элементы
        {
            foreach(int obj in lint)
            {
                if (!(obj%2 == 0))
                {
                    return false;
                }
            }
            return true;
        }

        public void Randomize(ref List<int> obj)
        {
            for (int i = 0; i < 3; i++)
            {
                obj.Add(MainClass.ran.Next(0, 10));
            }
        }

        public int Sum()
        {
            int rsum = 0;
            foreach(var obj in lint)
            {
                rsum += obj;
            }
            return rsum;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) throw new NullReferenceException();
            if (Sum() > (obj as TopClass).Sum()) return 1;
            if (Sum() < (obj as TopClass).Sum()) return -1;
            return 0;
        }

        public bool Equals(TopClass obj)
        {
            if (obj.lint.Count != lint.Count) return false;
            for (int i = 0; i < lint.Count; i++)
            {
                if (lint[i] != obj.lint[i]) return false;
            }
            return true;
        }
    }

    public class TopEnum : IEnumerator
    {
        public List<int> list;
        public int position = -1;

        public TopEnum(List<int> list)
        {
            this.list = list;
        }

        public bool MoveNext()
        {
            position++;
            return position < list.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public int Current
        {
            get
            {
                try
                {
                    return list[position];
                }
                catch(IndexOutOfRangeException)
                {
                    throw new Exception("Неверный индекс");
                }
            }
        }

    }

}
