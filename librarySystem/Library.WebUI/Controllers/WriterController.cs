using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using Library.VM.Writer;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    public class WriterController : Controller
    {
        public IWriterRepository Writer { get; }
        public IBookRepository Book { get; }

        public WriterController(IWriterRepository writer , IBookRepository book)
        {
            Writer = writer;
            Book = book;
        }
        #region All
        public IActionResult Index()
        {
            var model = Writer.GetAll();
            return View(model);
        }
        #endregion



        #region Add new
        [Route("/addnewWriter")]
        public async Task<IActionResult> AddCategory(TblWriter tbl)
        {
            TblWriter writer = new TblWriter
            {
                WriterName = tbl.WriterName

            };
            await Writer.Add(writer);
            return Redirect("/editWriter/" + writer.WriteId);
        }
        #endregion

        #region Edit
        [Route("/editWriter/{id}")]
        public async Task<IActionResult> editWriter(int id)
        {
            ForEditWriter model = new ForEditWriter
            {
                Writer = await Writer.GetByID(id),
                Books = Book.GetAll(),
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> editWriter(TblWriter tbl)
        {
            var old = await Writer.GetByID(tbl.WriteId);
            old.WriterName = tbl.WriterName;
            await Writer.Update(old);
            return Redirect("/editWriter/" + tbl.WriteId);
        }
        #endregion
    }
}
