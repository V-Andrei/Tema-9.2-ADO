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
            //xmlMethod();

            BookRepository bookRepository = new BookRepository();

            List<Book> books = bookRepository.GetAllBooks();

            string output = JsonConvert.SerializeObject(books);
        }

        private static void xmlMethod()
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Book));
            var books = new Book();


            var xml = "What is this?";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, books);
                    xml = sww.ToString(); 
                }
            }
        }
    }
}
