using Libirary.DAL.Models;
using Library.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.InterFaces
{
    public interface IBookRepository : IGeneralRepository<TblBook>
    {
        List<TblBook> GetBookByName(string name);
        List<TblBook> GetBookByCategory(int category);
        List<TblBook> GetBookByWriter(int Writer);
    }
}
