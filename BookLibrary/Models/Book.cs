using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    class Book
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public bool Istaken { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string TakenContactName { get; set; }
        public DateTime? TakenDate { get; set; }

    }
}
