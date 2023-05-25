using Libirary.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.VM.Category
{
    public class EditCategory
    {
        public TblCategory Category { get; set; }
        public List<TblBook> Books { get; set; }
    }
}
