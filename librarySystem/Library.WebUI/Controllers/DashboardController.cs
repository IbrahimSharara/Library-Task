using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IBorrowRepository Borrow { get; }

        public DashboardController(IBorrowRepository borrow)
        {
            Borrow = borrow;
        }


        public IActionResult Index()
        {
            var allBorrowedBooks = Borrow.GetAllWithBooks();
            return View(allBorrowedBooks);
        }

        public async Task<IActionResult> Details(int id)
        {
            await Borrow.ReveiceBook(id);
            return Redirect("/Dashboard/Index");
        }


        public async Task<IActionResult> UserBorrow(TblBorrow tbl)
        {
            var delay =  tbl.BorroTo - tbl.BorrowFrom;
            tbl.BorrowPrice = delay.Days * 10;
            await Borrow.Add(tbl);
            return Redirect("/home/Privacy?price=" + tbl.BorrowPrice + "&bookid=" + tbl.BookId);
        }


        public IActionResult DashboordNotification()
        {
            var allBorrowedBooks = Borrow.GetAllWithBooks();
            return PartialView(allBorrowedBooks);
        }
    }
}
