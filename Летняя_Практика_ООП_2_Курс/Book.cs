using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Летняя_Практика_ООП_2_Курс
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Annotation { get; set; }
        public int yearPublishing { get; set; }
        public string Author { get; set; }
        public string publishingHouse { get; set; }
        public string Interpreter { get; set; }
        public int numberPages { get; set; }
        public int readingRoomNumber { get; set; }
        public int rackNumber { get; set; } // стеллаж
        public int? CurrentReaderId { get; set; }
        public Reader CurrentReader { get; set; }
        public ICollection<Reader> PreviousReaders { get; set; }
}
}
