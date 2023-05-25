using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Repositories
{
    public class BorrowRepository : GeneralRepository<TblBorrow>, IBorrowRepository
    {
        public BorrowRepository(librarySystemContext dB) : base(dB)
        {
        }

        public List<TblBorrow> GetAllWithBooks()
        {
            return DB.TblBorrow.Include(x => x.Book).ToList();
        }

        public async Task<int> ReveiceBook(int id)
        {
            return await Delete(id);
            
        }

        public async Task<int> AddNewBorrow(TblBorrow tbl)
        {

            TimeSpan diff = (tbl.BorrowFrom - tbl.BorroTo) ;
            tbl.BorrowPrice = diff.Days * 10;
            return await AddNewBorrow(tbl);

        }
    }
}
