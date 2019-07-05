using System;
using System.Collections.Generic;
namespace OOP11
{
    static public class SuperClass //Класс для хранения метода расширения
    {
        static public IEnumerable<string> SummerWinter(this IEnumerable<string> values)
        {
            var result = new List<string>();
            var sumwinmon = new List<string>
            {
                "December", "January", "February", "June", "July", "August"
            };
            foreach(var obj in values)
            {
                if (sumwinmon.Contains(obj))
                {
                    result.Add(obj);
                }
            }
            return result;
        }
    }
}
