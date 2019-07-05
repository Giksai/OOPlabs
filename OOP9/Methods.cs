using System;
namespace OOP9
{
    public delegate string Del(string str);
    public static class Methods
    {
        public static void ConsoleOut(string str1, string str2, Action<string, string> act)
        => act(str1, str2);

        public static string RemoveSpaces(this string str, Func<string, string> fnc)
        => fnc(str);




        public static void Concat(this string str1, string str2)
        => str1 += str2;

        public static string ToUpperCase(this string str)
        {
            string newstr = "";
            for (int i = 0; i < str.Length; i++)
                newstr += char.ToUpper(str[i]);
            return newstr;
        }


    }
}
