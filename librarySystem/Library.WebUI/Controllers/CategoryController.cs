using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using Library.VM.Category;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(ICategoryRepository category , IBookRepository book)
        {
            Category = category;
            Book = book;
        }

        public ICategoryRepository Category { get; }
        public IBookRepository Book { get; }

        #region All
        public IActionResult Index()
        {
            var model = Category.GetAll();
            return View(model);
        }
        #endregion



        #region Add new
        [Route("/addnewCategory")]
        public async Task<IActionResult> AddCategory(TblCategory tbl)
        {
            TblCategory category = new TblCategory
            {
                CategoryName = tbl.CategoryName

            };
            await Category.Add(category);
            return Redirect("/editCategory/" + category.CategoryId);
        }
        #endregion

        #region Edit
        [Route("/editCategory/{id}")]
        public async Task<IActionResult> EditCategory(int id)
        {
            EditCategory model = new EditCategory
            {
                Category = await Category.GetByID(id),
                Books = Book.GetAll(),
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(TblCategory tbl)
        {
            var old = await Category.GetByID(tbl.CategoryId);
            old.CategoryName = tbl.CategoryName;
            await Category.Update(old);
            return Redirect("/editCategory/" + tbl.CategoryId);
        }
        #endregion
    }
}
