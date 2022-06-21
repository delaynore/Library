using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Летняя_Практика_ООП_2_Курс
{
    public class Reader
    {
        public int ReaderID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public HashSet<Book> familiarizedBooks { get; set; }
        public HashSet<Book> onHandsBooks { get; set; }
    }
}
