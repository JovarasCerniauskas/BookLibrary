using BookLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class BookReadWriteController
    {
        public List<Book> books { get; set; }

        public BookReadWriteController()
        {
            books = LoadData();
        }

        private List<Book> LoadData()
        {
                using (StreamReader r = new StreamReader("Json_data.json"))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Book>>(json);
                   
                }

            return null;
        }

        public void SaveData()
        {
            var json = JsonConvert.SerializeObject(books, Formatting.Indented);
            using (StreamWriter w = new StreamWriter("Json_data.json"))
            {
                w.Write(json);
            }

            //save books
        }
    }
}
