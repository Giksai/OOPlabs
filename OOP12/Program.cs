using System;

namespace OOP12
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //---1----
            //Reflector.WriteMembersClassToFile("TopClass");
            //----2---
            //Reflector.PrintPublicMethods("TopClass");
            //----3----
            //Reflector.PrintFieldsAndProperties("TopClass");
            //-----4----
            //Reflector.PrintInterfaces("TopClass");
            //----5----
            Reflector.PrintSpecifiedMethods("TopClass", typeof(string));
            //----6---
            //Reflector.InvokeMethod("TopClass", "NiceMethod");
        }
    }
}
