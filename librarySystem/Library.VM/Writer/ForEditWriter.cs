using Libirary.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.VM.Writer
{
    public class ForEditWriter
    {
        public List<TblBook> Books { get; set; }
        public TblWriter Writer { get; set; }
    }
}
