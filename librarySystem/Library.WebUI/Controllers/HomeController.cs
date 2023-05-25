using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using Library.VM.MainSite;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IBookRepository Book { get; }
        public ICategoryRepository Category { get; }
        public IWriterRepository Writer { get; }

        public HomeController(ILogger<HomeController> logger , IBookRepository book , ICategoryRepository category , IWriterRepository writer)
        {
            _logger = logger;
            Book = book;
            Category = category;
            Writer = writer;
        }

        public IActionResult Index()
        {
            var books = Book.GetAll();
            var writers = Writer.GetAll();
            var categories = Category.GetAll();
            GetAllDate model = new GetAllDate
            {
                Books = books,
                Categories = categories,
                Writers = writers
            };
            return View(model);
        }

        public async Task<IActionResult> Privacy(int price , int bookid)
        {
            var book =await Book.GetByID(bookid);
            Thanks model = new Thanks
            {
                Book = book,
                Price = price
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}