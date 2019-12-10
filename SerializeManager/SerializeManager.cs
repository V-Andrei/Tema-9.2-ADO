using DataAccess;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerializeManager
{
        class SerializeManager
    {
        static void Main(string[] args)
        {

            xmlMethod();

            //jsonMethod();
        }

        
        private static void jsonMethod()
        {
            BookRepository bookRepository = new BookRepository();

            List<Book> books = bookRepository.GetAllBooks();

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(@"d:\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, books);
            }
        }

        private static void xmlMethod()
        {
            BookRepository bookRepository = new BookRepository();

            List<Book> books = bookRepository.GetAllBooks();

            XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Book>));

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, books);
                    string xml = sww.ToString(); 

                    File.WriteAllText(@"d:\xml.txt",xml);
                }
            }

        }
    }
}
