using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model
{
    internal class bookModel
    {
        public int bookID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public string isbn { get; set; }
        public int availability { get; set; }
        public int change { get; set; }
    }
}
