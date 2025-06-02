using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
namespace SerializationBySOAP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test myObj = new Test();
            Stream myStream = File.OpenWrite("Serialization.ex");
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(myStream, myObj);
            myStream.Close();
            Console.WriteLine("Object has been Serialized!");

            FileStream file = new FileStream("Serialization.ex", FileMode.Open);
            SoapFormatter formatter2 = new SoapFormatter();
            Test myDeserializedObj = formatter2.Deserialize(file) as Test;
            Console.WriteLine(myDeserializedObj.name);
            Console.WriteLine(myDeserializedObj.phoneNumber);
            file.Close();
        }
    }
}
