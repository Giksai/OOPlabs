using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace SERIALIZATION
{
    public enum SerOpType
    {
        Serialize,
        Deserialize
    };

    public static class Serializator
    {
        public static Type SerializationBinary<Type>(Type clas, string filename, SerOpType OpType)
        {
            if (OpType == SerOpType.Deserialize && !File.Exists(filename))
            {
                Console.WriteLine("Файла не существует");
                return default(Type);
            }

            BinaryFormatter formatter = new BinaryFormatter();

            if (OpType == SerOpType.Serialize)
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, clas);
                }
            if (OpType == SerOpType.Deserialize)
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    return (Type)formatter.Deserialize(fs);
                }
            return default(Type);
        }

        public static Type SerializationSOAP<Type>(Type clas, string filename, SerOpType OpType)
        {
            if (OpType == SerOpType.Deserialize && !File.Exists(filename))
            {
                Console.WriteLine("Файла не существует");
                return default(Type);
            }

            SoapFormatter formatter = new SoapFormatter();

            if (OpType == SerOpType.Serialize)
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, clas);
                }
            if (OpType == SerOpType.Deserialize)
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    return (Type)formatter.Deserialize(fs);
                }
            return default(Type);
        }

        public static Type SerializationXML<Type>(Type clas, string filename, SerOpType OpType)
        {
            if (OpType == SerOpType.Deserialize && !File.Exists(filename))
            {
                Console.WriteLine("Файла не существует");
                return default(Type);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Type));

            if (OpType == SerOpType.Serialize)
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, clas);
            }
            if (OpType == SerOpType.Deserialize)
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    return (Type)serializer.Deserialize(fs);
                }
            return default(Type);
           
        }

        public static Type SerializationJSON<Type>(Type clas, string filename, SerOpType OpType)
        {
            if (OpType == SerOpType.Deserialize && !File.Exists(filename))
            {
                Console.WriteLine("Файла не существует");
                return default(Type);
            }

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Type));

            if (OpType == SerOpType.Serialize)
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                    formatter.WriteObject(fs, clas);
            }
            if (OpType == SerOpType.Deserialize)
                using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                   return (Type)formatter.ReadObject(fs);
            }
            return default(Type);

        }

        public static void XPATHquery(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Файла не существует");
                return;
            }
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(filename);
            XmlElement elem1 = xdoc.DocumentElement;

            Console.WriteLine("Первый запрос:");
            XmlNodeList lst1 = elem1.SelectNodes("*");
            foreach(XmlNode obj in lst1)
            {
                Console.WriteLine(obj.InnerXml);
            }

            Console.WriteLine("Второй запрос: ");
            foreach(XmlNode obj in lst1)
            {
                Console.WriteLine(obj.SelectSingleNode("ID").InnerText); 
            }

            Console.WriteLine("Второй запрос с другой реализацией: ");
            foreach(XmlNode obj in elem1.SelectNodes("//Ball/ID"))
            {
                Console.WriteLine(obj.InnerText);
            }
        }

        public static void XMLLINQquery(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Файла не существует");
                return;
            }

            XDocument xdoc = XDocument.Load(filename);

            var item = from xe in xdoc.Element("ArrayOfBall").Elements("Ball")
                                          where xe.Element("ID").Value == 3.ToString()
                                      select xe.Element("Pressure").Value;
            Console.WriteLine("Linq запрос: ");
            foreach(var obj in item)
            {
                Console.WriteLine(obj);
            }

        }


    } 
}
