using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using Library.VM.Book;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    public class BookController : Controller
    {
        public BookController(IBookRepository book , ICategoryRepository category , IWriterRepository writer , IBorrowRepository borrow)
        {
            Book = book;
            Category = category;
            Writer = writer;
            Borrow = borrow;
        }

        public IBookRepository Book { get; }
        public ICategoryRepository Category { get; }
        public IWriterRepository Writer { get; }
        public IBorrowRepository Borrow { get; }
        #region All
        public IActionResult Index()
        {
            var model = Book.GetAll();
            return View(model);
        }
        #endregion

        #region Add new
        public async Task<IActionResult> AddBook()
        {
            TblBook book = new TblBook
            {
                AvailableNumber = 0 ,
                BookPhoto = "",
                IsAvailable = false,
            };
            await Book.Add(book);
            return Redirect("/editBook/" + book.BookId);
        }
        #endregion

        #region Details for user
        public async Task<IActionResult> details(int id)
        {
            return View(await Book.GetByID(id));
        }
        #endregion

        #region Edit
        [Route("/editBook/{id}")]
        public async Task<IActionResult> EditBook(int id)
        {
            EditCategory model = new EditCategory
            {
                Book = await Book.GetByID(id),
                Categories = Category.GetAll(),
                writers = Writer.GetAll()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditBook(TblBook tbl , string IsAvailable)
        {
            var old = await Book.GetByID(tbl.BookId);
            old.AvailableNumber = tbl.AvailableNumber;
            old.BookName = tbl.BookName;
            old.BookIntro = tbl.BookIntro;
            old.BookDetails = tbl.BookDetails;
            old.BookWriter = tbl.BookWriter;
            old.BookCategory = tbl.BookCategory;
            if (IsAvailable == "on")
                old.IsAvailable = true;
            else
                old.IsAvailable = false;
            await Book.Update(old);
            return Redirect("/editBook/" + tbl.BookId);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int ID)
        {
            await Book.Delete(ID);
            return Redirect("/Book/Index");
        }
        #endregion

        #region Add Photo
        [HttpPost]
        public async Task<IActionResult> addPhoto(IFormFile file, int id)
        {
            var book = await Book.GetByID(id);
            if (file != null)
            {
                string filename = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);
                using (Stream stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                book.BookPhoto = filename;
            }
            await Book.Update( book);
            return Redirect("/editBook/" + id);
        }
        #endregion


        #region get by book Name
        public IActionResult bookName(string name)
        {
            var books = Book.GetBookByName(name);
            return PartialView(books);
        }
        #endregion
        
        #region get by Category
        public IActionResult ByCategory(int id)
        {
            var books = Book.GetBookByCategory(id);
            return PartialView("bookName", books);
        }
        #endregion

        #region get by Writer
        public IActionResult ByWriter(int id)
        {
            var books = Book.GetBookByWriter(id);
            return PartialView("bookName", books);
        }
        #endregion

        #region get by Writer or book name or category
        public IActionResult Get(int Category, string BookName , int writer)
        {
            var writers = Book.GetBookByWriter(writer);
            var BookNames = Book.GetBookByName(BookName);
            var BookCategory = Book.GetBookByCategory(Category);
            List<TblBook> books = new List<TblBook>();
            books.AddRange(writers);
            books.AddRange(BookNames);
            books.AddRange(BookCategory);
            return PartialView("bookName", books.Distinct());
        }
        #endregion


    }
}