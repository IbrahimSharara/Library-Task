using Libirary.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.VM.Book
{
    public class EditCategory
    {
        public TblBook Book { get; set; }
        public List<TblCategory> Categories { get; set; }
        public List<TblWriter> writers { get; set; }
    }
}
