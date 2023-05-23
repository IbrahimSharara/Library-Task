using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Repositories
{
    public class BookRepository : GeneralRepository<TblBook>, IBookRepository
    {
        public BookRepository(librarySystemContext dB) : base(dB)
        {
        }

        public List<TblBook> GetBookByCategory(int category)
        {
            return DB.TblBook.Where(x => x.BookCategory == category).ToList();
        }

        public List<TblBook> GetBookByName(string name)
        {
            return DB.TblBook.Where(x => x.BookName == name).ToList();
        }

        public List<TblBook> GetBookByWriter(int Writer)
        {
            return DB.TblBook.Where(x => x.BookWriter == Writer).ToList();
        }
    }
}
