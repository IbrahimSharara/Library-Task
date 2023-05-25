using Libirary.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.VM.MainSite
{
    public class GetAllDate
    {
        public List<TblBook> Books { get; set; }
        public List<TblWriter> Writers { get; set; }
        public List<TblCategory> Categories { get; set; }
    }
}
